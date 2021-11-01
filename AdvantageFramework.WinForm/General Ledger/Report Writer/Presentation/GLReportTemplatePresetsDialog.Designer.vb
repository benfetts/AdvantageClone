Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplatePresetsDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplatePresetsDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlForm_OptionsPresets = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.PictureOptions_UpdateCurrencyImage = New DevExpress.XtraEditors.PictureEdit()
            Me.SearchableComboBoxOptions_Currency = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView9 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.NumericInputOptions_CurrencyExchangeRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelOptions_CurrencyExchangeRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOptions_Currency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxOptions_SortRowsBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_SortRowsBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonOptions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.RadioButtonOptions_UserDefined = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOptions_Default = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelOptions_CustomReport = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonOptions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOptions_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOptions_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewOptions_GLReportUDRs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ComboBoxOptions_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemOptionsPresets_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelDepartmentTeam_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelDepartmentTeam_DTRightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonDTRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonDTRightSection_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonDTRightSection_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonDTRightSection_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewDTRightSection_Presets = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelDepartmentTeam_DTLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewDTLeftSection_DepartmentTeams = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReportTemplatePresets_DepartmentTeamTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOfficeTab_Office = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelOffice_Office = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelOffice_OfficeRightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonOfficeRightSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOfficeRightSection_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewOfficeRightSection_Presets = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonOfficeRightSection_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonOfficeRightSection_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ExpandableSplitterOffice_OfficeLeftRightSection = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelOffice_OfficeLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewOfficeLeftSection_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReportTemplatePresets_OfficeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonForm_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.TabControlForm_OptionsPresets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_OptionsPresets.SuspendLayout()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            CType(Me.PictureOptions_UpdateCurrencyImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxOptions_Currency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputOptions_CurrencyExchangeRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.SuspendLayout()
            CType(Me.PanelDepartmentTeam_DepartmentTeam, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDepartmentTeam_DepartmentTeam.SuspendLayout()
            CType(Me.PanelDepartmentTeam_DTRightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDepartmentTeam_DTRightSection.SuspendLayout()
            CType(Me.PanelDepartmentTeam_DTLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDepartmentTeam_DTLeftSection.SuspendLayout()
            Me.TabControlPanelOfficeTab_Office.SuspendLayout()
            CType(Me.PanelOffice_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOffice_Office.SuspendLayout()
            CType(Me.PanelOffice_OfficeRightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOffice_OfficeRightSection.SuspendLayout()
            CType(Me.PanelOffice_OfficeLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOffice_OfficeLeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(727, 391)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'TabControlForm_OptionsPresets
            '
            Me.TabControlForm_OptionsPresets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_OptionsPresets.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_OptionsPresets.CanReorderTabs = False
            Me.TabControlForm_OptionsPresets.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_OptionsPresets.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelOptionsTab_Options)
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelDepartmentTeamTab_DepartmentTeam)
            Me.TabControlForm_OptionsPresets.Controls.Add(Me.TabControlPanelOfficeTab_Office)
            Me.TabControlForm_OptionsPresets.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_OptionsPresets.Name = "TabControlForm_OptionsPresets"
            Me.TabControlForm_OptionsPresets.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_OptionsPresets.SelectedTabIndex = 0
            Me.TabControlForm_OptionsPresets.Size = New System.Drawing.Size(790, 373)
            Me.TabControlForm_OptionsPresets.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_OptionsPresets.TabIndex = 0
            Me.TabControlForm_OptionsPresets.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemOptionsPresets_OptionsTab)
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemReportTemplatePresets_OfficeTab)
            Me.TabControlForm_OptionsPresets.Tabs.Add(Me.TabItemReportTemplatePresets_DepartmentTeamTab)
            Me.TabControlForm_OptionsPresets.Text = "TabControl1"
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PictureOptions_UpdateCurrencyImage)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.SearchableComboBoxOptions_Currency)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.NumericInputOptions_CurrencyExchangeRate)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_CurrencyExchangeRate)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_Currency)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxOptions_SortRowsBy)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_SortRowsBy)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ButtonOptions_Copy)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.RadioButtonOptions_UserDefined)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.RadioButtonOptions_Default)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_CustomReport)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ButtonOptions_Delete)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ButtonOptions_Edit)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ButtonOptions_Add)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.DataGridViewOptions_GLReportUDRs)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxOptions_PostPeriod)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_PostPeriod)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(790, 346)
            Me.TabControlPanelOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelOptionsTab_Options.TabIndex = 0
            Me.TabControlPanelOptionsTab_Options.TabItem = Me.TabItemOptionsPresets_OptionsTab
            '
            'PictureOptions_UpdateCurrencyImage
            '
            Me.PictureOptions_UpdateCurrencyImage.Cursor = System.Windows.Forms.Cursors.Help
            Me.PictureOptions_UpdateCurrencyImage.Location = New System.Drawing.Point(520, 33)
            Me.PictureOptions_UpdateCurrencyImage.Name = "PictureOptions_UpdateCurrencyImage"
            Me.PictureOptions_UpdateCurrencyImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
            Me.PictureOptions_UpdateCurrencyImage.Properties.ZoomAccelerationFactor = 1.0R
            Me.PictureOptions_UpdateCurrencyImage.Size = New System.Drawing.Size(20, 20)
            Me.PictureOptions_UpdateCurrencyImage.TabIndex = 105
            Me.PictureOptions_UpdateCurrencyImage.ToolTip = "Click the image to sign-up for free at:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "https://currencylayer.com/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.PictureOptions_UpdateCurrencyImage.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
            Me.PictureOptions_UpdateCurrencyImage.Visible = False
            '
            'SearchableComboBoxOptions_Currency
            '
            Me.SearchableComboBoxOptions_Currency.ActiveFilterString = ""
            Me.SearchableComboBoxOptions_Currency.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxOptions_Currency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxOptions_Currency.AutoFillMode = False
            Me.SearchableComboBoxOptions_Currency.BookmarkingEnabled = False
            Me.SearchableComboBoxOptions_Currency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CurrencyCode
            Me.SearchableComboBoxOptions_Currency.DataSource = Nothing
            Me.SearchableComboBoxOptions_Currency.DisableMouseWheel = False
            Me.SearchableComboBoxOptions_Currency.DisplayName = ""
            Me.SearchableComboBoxOptions_Currency.EnterMoveNextControl = True
            Me.SearchableComboBoxOptions_Currency.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxOptions_Currency.Location = New System.Drawing.Point(77, 33)
            Me.SearchableComboBoxOptions_Currency.Name = "SearchableComboBoxOptions_Currency"
            Me.SearchableComboBoxOptions_Currency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxOptions_Currency.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxOptions_Currency.Properties.NullText = "Select Currency Code"
            Me.SearchableComboBoxOptions_Currency.Properties.ValueMember = "Code"
            Me.SearchableComboBoxOptions_Currency.Properties.View = Me.GridView9
            Me.SearchableComboBoxOptions_Currency.SecurityEnabled = True
            Me.SearchableComboBoxOptions_Currency.SelectedValue = Nothing
            Me.SearchableComboBoxOptions_Currency.Size = New System.Drawing.Size(186, 20)
            Me.SearchableComboBoxOptions_Currency.TabIndex = 3
            '
            'GridView9
            '
            Me.GridView9.AFActiveFilterString = ""
            Me.GridView9.AllowExtraItemsInGridLookupEdits = True
            Me.GridView9.AutoFilterLookupColumns = False
            Me.GridView9.AutoloadRepositoryDatasource = True
            Me.GridView9.DataSourceClearing = False
            Me.GridView9.EnableDisabledRows = False
            Me.GridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView9.Name = "GridView9"
            Me.GridView9.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView9.OptionsView.ShowGroupPanel = False
            Me.GridView9.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView9.RunStandardValidation = True
            '
            'NumericInputOptions_CurrencyExchangeRate
            '
            Me.NumericInputOptions_CurrencyExchangeRate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputOptions_CurrencyExchangeRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputOptions_CurrencyExchangeRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputOptions_CurrencyExchangeRate.EnterMoveNextControl = True
            Me.NumericInputOptions_CurrencyExchangeRate.Location = New System.Drawing.Point(411, 33)
            Me.NumericInputOptions_CurrencyExchangeRate.Name = "NumericInputOptions_CurrencyExchangeRate"
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.AllowMouseWheel = False
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.Mask.EditMask = "f"
            Me.NumericInputOptions_CurrencyExchangeRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputOptions_CurrencyExchangeRate.SecurityEnabled = True
            Me.NumericInputOptions_CurrencyExchangeRate.Size = New System.Drawing.Size(103, 20)
            Me.NumericInputOptions_CurrencyExchangeRate.TabIndex = 8
            '
            'LabelOptions_CurrencyExchangeRate
            '
            Me.LabelOptions_CurrencyExchangeRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_CurrencyExchangeRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_CurrencyExchangeRate.Location = New System.Drawing.Point(269, 33)
            Me.LabelOptions_CurrencyExchangeRate.Name = "LabelOptions_CurrencyExchangeRate"
            Me.LabelOptions_CurrencyExchangeRate.Size = New System.Drawing.Size(136, 20)
            Me.LabelOptions_CurrencyExchangeRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_CurrencyExchangeRate.TabIndex = 7
            Me.LabelOptions_CurrencyExchangeRate.Text = "Currency Exchange Rate:"
            '
            'LabelOptions_Currency
            '
            Me.LabelOptions_Currency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_Currency.Location = New System.Drawing.Point(4, 33)
            Me.LabelOptions_Currency.Name = "LabelOptions_Currency"
            Me.LabelOptions_Currency.Size = New System.Drawing.Size(67, 20)
            Me.LabelOptions_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_Currency.TabIndex = 5
            Me.LabelOptions_Currency.Text = "Currency:"
            '
            'ComboBoxOptions_SortRowsBy
            '
            Me.ComboBoxOptions_SortRowsBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_SortRowsBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxOptions_SortRowsBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_SortRowsBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_SortRowsBy.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_SortRowsBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_SortRowsBy.BookmarkingEnabled = False
            Me.ComboBoxOptions_SortRowsBy.ClientCode = ""
            Me.ComboBoxOptions_SortRowsBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxOptions_SortRowsBy.DisableMouseWheel = False
            Me.ComboBoxOptions_SortRowsBy.DisplayMember = "Name"
            Me.ComboBoxOptions_SortRowsBy.DisplayName = ""
            Me.ComboBoxOptions_SortRowsBy.DivisionCode = ""
            Me.ComboBoxOptions_SortRowsBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_SortRowsBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOptions_SortRowsBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxOptions_SortRowsBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_SortRowsBy.FocusHighlightEnabled = True
            Me.ComboBoxOptions_SortRowsBy.FormattingEnabled = True
            Me.ComboBoxOptions_SortRowsBy.ItemHeight = 14
            Me.ComboBoxOptions_SortRowsBy.Location = New System.Drawing.Point(583, 4)
            Me.ComboBoxOptions_SortRowsBy.Name = "ComboBoxOptions_SortRowsBy"
            Me.ComboBoxOptions_SortRowsBy.ReadOnly = False
            Me.ComboBoxOptions_SortRowsBy.SecurityEnabled = True
            Me.ComboBoxOptions_SortRowsBy.Size = New System.Drawing.Size(203, 20)
            Me.ComboBoxOptions_SortRowsBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_SortRowsBy.TabIndex = 4
            Me.ComboBoxOptions_SortRowsBy.TabOnEnter = True
            Me.ComboBoxOptions_SortRowsBy.ValueMember = "Value"
            Me.ComboBoxOptions_SortRowsBy.WatermarkText = "Select"
            '
            'LabelOptions_SortRowsBy
            '
            Me.LabelOptions_SortRowsBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_SortRowsBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_SortRowsBy.Location = New System.Drawing.Point(501, 4)
            Me.LabelOptions_SortRowsBy.Name = "LabelOptions_SortRowsBy"
            Me.LabelOptions_SortRowsBy.Size = New System.Drawing.Size(76, 20)
            Me.LabelOptions_SortRowsBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_SortRowsBy.TabIndex = 3
            Me.LabelOptions_SortRowsBy.Text = "Sort Rows By:"
            '
            'CheckBoxOptions_PrintColumnHeadingsOnEveryPage
            '
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.CheckValue = 0
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.CheckValueChecked = 1
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.CheckValueUnchecked = 0
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.ChildControls = Nothing
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.Location = New System.Drawing.Point(269, 4)
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.Name = "CheckBoxOptions_PrintColumnHeadingsOnEveryPage"
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.OldestSibling = Nothing
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.SecurityEnabled = True
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.SiblingControls = Nothing
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.Size = New System.Drawing.Size(226, 20)
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.TabIndex = 2
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.TabOnEnter = True
            Me.CheckBoxOptions_PrintColumnHeadingsOnEveryPage.Text = "Print Column Headings on Every Page"
            '
            'ButtonOptions_Copy
            '
            Me.ButtonOptions_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonOptions_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_Copy.Location = New System.Drawing.Point(247, 322)
            Me.ButtonOptions_Copy.Name = "ButtonOptions_Copy"
            Me.ButtonOptions_Copy.SecurityEnabled = True
            Me.ButtonOptions_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_Copy.TabIndex = 16
            Me.ButtonOptions_Copy.Text = "Copy"
            '
            'RadioButtonOptions_UserDefined
            '
            Me.RadioButtonOptions_UserDefined.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOptions_UserDefined.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOptions_UserDefined.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOptions_UserDefined.Location = New System.Drawing.Point(77, 85)
            Me.RadioButtonOptions_UserDefined.Name = "RadioButtonOptions_UserDefined"
            Me.RadioButtonOptions_UserDefined.SecurityEnabled = True
            Me.RadioButtonOptions_UserDefined.Size = New System.Drawing.Size(227, 20)
            Me.RadioButtonOptions_UserDefined.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOptions_UserDefined.TabIndex = 11
            Me.RadioButtonOptions_UserDefined.TabOnEnter = True
            Me.RadioButtonOptions_UserDefined.TabStop = False
            Me.RadioButtonOptions_UserDefined.Text = "User Defined"
            '
            'RadioButtonOptions_Default
            '
            Me.RadioButtonOptions_Default.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOptions_Default.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOptions_Default.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOptions_Default.Checked = True
            Me.RadioButtonOptions_Default.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonOptions_Default.CheckValue = "Y"
            Me.RadioButtonOptions_Default.Location = New System.Drawing.Point(4, 85)
            Me.RadioButtonOptions_Default.Name = "RadioButtonOptions_Default"
            Me.RadioButtonOptions_Default.SecurityEnabled = True
            Me.RadioButtonOptions_Default.Size = New System.Drawing.Size(67, 20)
            Me.RadioButtonOptions_Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOptions_Default.TabIndex = 10
            Me.RadioButtonOptions_Default.TabOnEnter = True
            Me.RadioButtonOptions_Default.Text = "Default"
            '
            'LabelOptions_CustomReport
            '
            Me.LabelOptions_CustomReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelOptions_CustomReport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_CustomReport.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_CustomReport.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_CustomReport.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_CustomReport.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_CustomReport.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_CustomReport.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_CustomReport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_CustomReport.Location = New System.Drawing.Point(4, 59)
            Me.LabelOptions_CustomReport.Name = "LabelOptions_CustomReport"
            Me.LabelOptions_CustomReport.Size = New System.Drawing.Size(779, 20)
            Me.LabelOptions_CustomReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_CustomReport.TabIndex = 9
            Me.LabelOptions_CustomReport.Text = "Custom Report"
            '
            'ButtonOptions_Delete
            '
            Me.ButtonOptions_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonOptions_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_Delete.Enabled = False
            Me.ButtonOptions_Delete.Location = New System.Drawing.Point(166, 322)
            Me.ButtonOptions_Delete.Name = "ButtonOptions_Delete"
            Me.ButtonOptions_Delete.SecurityEnabled = True
            Me.ButtonOptions_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_Delete.TabIndex = 15
            Me.ButtonOptions_Delete.Text = "Delete"
            '
            'ButtonOptions_Edit
            '
            Me.ButtonOptions_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonOptions_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_Edit.Enabled = False
            Me.ButtonOptions_Edit.Location = New System.Drawing.Point(85, 322)
            Me.ButtonOptions_Edit.Name = "ButtonOptions_Edit"
            Me.ButtonOptions_Edit.SecurityEnabled = True
            Me.ButtonOptions_Edit.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_Edit.TabIndex = 14
            Me.ButtonOptions_Edit.Text = "Edit"
            '
            'ButtonOptions_Add
            '
            Me.ButtonOptions_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonOptions_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_Add.Enabled = False
            Me.ButtonOptions_Add.Location = New System.Drawing.Point(4, 322)
            Me.ButtonOptions_Add.Name = "ButtonOptions_Add"
            Me.ButtonOptions_Add.SecurityEnabled = True
            Me.ButtonOptions_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_Add.TabIndex = 13
            Me.ButtonOptions_Add.Text = "Add"
            '
            'DataGridViewOptions_GLReportUDRs
            '
            Me.DataGridViewOptions_GLReportUDRs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOptions_GLReportUDRs.AllowDragAndDrop = False
            Me.DataGridViewOptions_GLReportUDRs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOptions_GLReportUDRs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOptions_GLReportUDRs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOptions_GLReportUDRs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOptions_GLReportUDRs.AutoFilterLookupColumns = False
            Me.DataGridViewOptions_GLReportUDRs.AutoloadRepositoryDatasource = True
            Me.DataGridViewOptions_GLReportUDRs.AutoUpdateViewCaption = True
            Me.DataGridViewOptions_GLReportUDRs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewOptions_GLReportUDRs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOptions_GLReportUDRs.Enabled = False
            Me.DataGridViewOptions_GLReportUDRs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOptions_GLReportUDRs.ItemDescription = "Item(s)"
            Me.DataGridViewOptions_GLReportUDRs.Location = New System.Drawing.Point(4, 111)
            Me.DataGridViewOptions_GLReportUDRs.MultiSelect = True
            Me.DataGridViewOptions_GLReportUDRs.Name = "DataGridViewOptions_GLReportUDRs"
            Me.DataGridViewOptions_GLReportUDRs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOptions_GLReportUDRs.RunStandardValidation = True
            Me.DataGridViewOptions_GLReportUDRs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOptions_GLReportUDRs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOptions_GLReportUDRs.Size = New System.Drawing.Size(782, 205)
            Me.DataGridViewOptions_GLReportUDRs.TabIndex = 12
            Me.DataGridViewOptions_GLReportUDRs.UseEmbeddedNavigator = False
            Me.DataGridViewOptions_GLReportUDRs.ViewCaptionHeight = -1
            '
            'ComboBoxOptions_PostPeriod
            '
            Me.ComboBoxOptions_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_PostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_PostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_PostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_PostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_PostPeriod.BookmarkingEnabled = False
            Me.ComboBoxOptions_PostPeriod.ClientCode = ""
            Me.ComboBoxOptions_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxOptions_PostPeriod.DisableMouseWheel = False
            Me.ComboBoxOptions_PostPeriod.DisplayMember = "Description"
            Me.ComboBoxOptions_PostPeriod.DisplayName = ""
            Me.ComboBoxOptions_PostPeriod.DivisionCode = ""
            Me.ComboBoxOptions_PostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOptions_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOptions_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_PostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxOptions_PostPeriod.FormattingEnabled = True
            Me.ComboBoxOptions_PostPeriod.ItemHeight = 14
            Me.ComboBoxOptions_PostPeriod.Location = New System.Drawing.Point(77, 4)
            Me.ComboBoxOptions_PostPeriod.Name = "ComboBoxOptions_PostPeriod"
            Me.ComboBoxOptions_PostPeriod.ReadOnly = False
            Me.ComboBoxOptions_PostPeriod.SecurityEnabled = True
            Me.ComboBoxOptions_PostPeriod.Size = New System.Drawing.Size(186, 20)
            Me.ComboBoxOptions_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_PostPeriod.TabIndex = 1
            Me.ComboBoxOptions_PostPeriod.TabOnEnter = True
            Me.ComboBoxOptions_PostPeriod.ValueMember = "Code"
            Me.ComboBoxOptions_PostPeriod.WatermarkText = "Select Post Period"
            '
            'LabelOptions_PostPeriod
            '
            Me.LabelOptions_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_PostPeriod.Location = New System.Drawing.Point(4, 4)
            Me.LabelOptions_PostPeriod.Name = "LabelOptions_PostPeriod"
            Me.LabelOptions_PostPeriod.Size = New System.Drawing.Size(67, 20)
            Me.LabelOptions_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_PostPeriod.TabIndex = 0
            Me.LabelOptions_PostPeriod.Text = "Post Period:"
            '
            'TabItemOptionsPresets_OptionsTab
            '
            Me.TabItemOptionsPresets_OptionsTab.AttachedControl = Me.TabControlPanelOptionsTab_Options
            Me.TabItemOptionsPresets_OptionsTab.Name = "TabItemOptionsPresets_OptionsTab"
            Me.TabItemOptionsPresets_OptionsTab.Text = "Options"
            '
            'TabControlPanelDepartmentTeamTab_DepartmentTeam
            '
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Controls.Add(Me.PanelDepartmentTeam_DepartmentTeam)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Name = "TabControlPanelDepartmentTeamTab_DepartmentTeam"
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Size = New System.Drawing.Size(790, 346)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.Style.GradientAngle = 90
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.TabIndex = 0
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.TabItem = Me.TabItemReportTemplatePresets_DepartmentTeamTab
            '
            'PanelDepartmentTeam_DepartmentTeam
            '
            Me.PanelDepartmentTeam_DepartmentTeam.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelDepartmentTeam_DepartmentTeam.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDepartmentTeam_DepartmentTeam.Appearance.Options.UseBackColor = True
            Me.PanelDepartmentTeam_DepartmentTeam.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelDepartmentTeam_DepartmentTeam.Controls.Add(Me.PanelDepartmentTeam_DTRightSection)
            Me.PanelDepartmentTeam_DepartmentTeam.Controls.Add(Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection)
            Me.PanelDepartmentTeam_DepartmentTeam.Controls.Add(Me.PanelDepartmentTeam_DTLeftSection)
            Me.PanelDepartmentTeam_DepartmentTeam.Location = New System.Drawing.Point(4, 4)
            Me.PanelDepartmentTeam_DepartmentTeam.Name = "PanelDepartmentTeam_DepartmentTeam"
            Me.PanelDepartmentTeam_DepartmentTeam.Size = New System.Drawing.Size(782, 338)
            Me.PanelDepartmentTeam_DepartmentTeam.TabIndex = 0
            '
            'PanelDepartmentTeam_DTRightSection
            '
            Me.PanelDepartmentTeam_DTRightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDepartmentTeam_DTRightSection.Appearance.Options.UseBackColor = True
            Me.PanelDepartmentTeam_DTRightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.ButtonDTRightSection_Add)
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.ButtonDTRightSection_AddAll)
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.ButtonDTRightSection_RemoveAll)
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.ButtonDTRightSection_Remove)
            Me.PanelDepartmentTeam_DTRightSection.Controls.Add(Me.DataGridViewDTRightSection_Presets)
            Me.PanelDepartmentTeam_DTRightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelDepartmentTeam_DTRightSection.Location = New System.Drawing.Point(309, 0)
            Me.PanelDepartmentTeam_DTRightSection.Name = "PanelDepartmentTeam_DTRightSection"
            Me.PanelDepartmentTeam_DTRightSection.Size = New System.Drawing.Size(473, 338)
            Me.PanelDepartmentTeam_DTRightSection.TabIndex = 2
            '
            'ButtonDTRightSection_Add
            '
            Me.ButtonDTRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDTRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDTRightSection_Add.Location = New System.Drawing.Point(6, 0)
            Me.ButtonDTRightSection_Add.Name = "ButtonDTRightSection_Add"
            Me.ButtonDTRightSection_Add.SecurityEnabled = True
            Me.ButtonDTRightSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDTRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDTRightSection_Add.TabIndex = 0
            Me.ButtonDTRightSection_Add.Text = ">"
            '
            'ButtonDTRightSection_AddAll
            '
            Me.ButtonDTRightSection_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDTRightSection_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDTRightSection_AddAll.Location = New System.Drawing.Point(6, 26)
            Me.ButtonDTRightSection_AddAll.Name = "ButtonDTRightSection_AddAll"
            Me.ButtonDTRightSection_AddAll.SecurityEnabled = True
            Me.ButtonDTRightSection_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDTRightSection_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDTRightSection_AddAll.TabIndex = 1
            Me.ButtonDTRightSection_AddAll.Text = ">>"
            '
            'ButtonDTRightSection_RemoveAll
            '
            Me.ButtonDTRightSection_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDTRightSection_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDTRightSection_RemoveAll.Location = New System.Drawing.Point(6, 78)
            Me.ButtonDTRightSection_RemoveAll.Name = "ButtonDTRightSection_RemoveAll"
            Me.ButtonDTRightSection_RemoveAll.SecurityEnabled = True
            Me.ButtonDTRightSection_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDTRightSection_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDTRightSection_RemoveAll.TabIndex = 3
            Me.ButtonDTRightSection_RemoveAll.Text = "<<"
            '
            'ButtonDTRightSection_Remove
            '
            Me.ButtonDTRightSection_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDTRightSection_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDTRightSection_Remove.Location = New System.Drawing.Point(6, 52)
            Me.ButtonDTRightSection_Remove.Name = "ButtonDTRightSection_Remove"
            Me.ButtonDTRightSection_Remove.SecurityEnabled = True
            Me.ButtonDTRightSection_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonDTRightSection_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDTRightSection_Remove.TabIndex = 2
            Me.ButtonDTRightSection_Remove.Text = "<"
            '
            'DataGridViewDTRightSection_Presets
            '
            Me.DataGridViewDTRightSection_Presets.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewDTRightSection_Presets.AllowDragAndDrop = False
            Me.DataGridViewDTRightSection_Presets.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDTRightSection_Presets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDTRightSection_Presets.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDTRightSection_Presets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDTRightSection_Presets.AutoFilterLookupColumns = False
            Me.DataGridViewDTRightSection_Presets.AutoloadRepositoryDatasource = True
            Me.DataGridViewDTRightSection_Presets.AutoUpdateViewCaption = True
            Me.DataGridViewDTRightSection_Presets.BackColor = System.Drawing.Color.White
            Me.DataGridViewDTRightSection_Presets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewDTRightSection_Presets.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDTRightSection_Presets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDTRightSection_Presets.ItemDescription = ""
            Me.DataGridViewDTRightSection_Presets.Location = New System.Drawing.Point(87, 0)
            Me.DataGridViewDTRightSection_Presets.MultiSelect = True
            Me.DataGridViewDTRightSection_Presets.Name = "DataGridViewDTRightSection_Presets"
            Me.DataGridViewDTRightSection_Presets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDTRightSection_Presets.RunStandardValidation = True
            Me.DataGridViewDTRightSection_Presets.ShowColumnMenuOnRightClick = False
            Me.DataGridViewDTRightSection_Presets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDTRightSection_Presets.Size = New System.Drawing.Size(386, 338)
            Me.DataGridViewDTRightSection_Presets.TabIndex = 4
            Me.DataGridViewDTRightSection_Presets.UseEmbeddedNavigator = False
            Me.DataGridViewDTRightSection_Presets.ViewCaptionHeight = -1
            '
            'ExpandableSplitterDepartmentTeam_DTLeftRightSection
            '
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.Location = New System.Drawing.Point(303, 0)
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.Name = "ExpandableSplitterDepartmentTeam_DTLeftRightSection"
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.Size = New System.Drawing.Size(6, 338)
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.TabIndex = 1
            Me.ExpandableSplitterDepartmentTeam_DTLeftRightSection.TabStop = False
            '
            'PanelDepartmentTeam_DTLeftSection
            '
            Me.PanelDepartmentTeam_DTLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelDepartmentTeam_DTLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelDepartmentTeam_DTLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelDepartmentTeam_DTLeftSection.Controls.Add(Me.DataGridViewDTLeftSection_DepartmentTeams)
            Me.PanelDepartmentTeam_DTLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelDepartmentTeam_DTLeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelDepartmentTeam_DTLeftSection.Name = "PanelDepartmentTeam_DTLeftSection"
            Me.PanelDepartmentTeam_DTLeftSection.Size = New System.Drawing.Size(303, 338)
            Me.PanelDepartmentTeam_DTLeftSection.TabIndex = 0
            '
            'DataGridViewDTLeftSection_DepartmentTeams
            '
            Me.DataGridViewDTLeftSection_DepartmentTeams.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.AllowDragAndDrop = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDTLeftSection_DepartmentTeams.AutoFilterLookupColumns = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.AutoloadRepositoryDatasource = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.AutoUpdateViewCaption = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.BackColor = System.Drawing.Color.White
            Me.DataGridViewDTLeftSection_DepartmentTeams.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewDTLeftSection_DepartmentTeams.DataSource = Nothing
            Me.DataGridViewDTLeftSection_DepartmentTeams.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDTLeftSection_DepartmentTeams.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDTLeftSection_DepartmentTeams.ItemDescription = ""
            Me.DataGridViewDTLeftSection_DepartmentTeams.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewDTLeftSection_DepartmentTeams.MultiSelect = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.Name = "DataGridViewDTLeftSection_DepartmentTeams"
            Me.DataGridViewDTLeftSection_DepartmentTeams.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDTLeftSection_DepartmentTeams.RunStandardValidation = True
            Me.DataGridViewDTLeftSection_DepartmentTeams.ShowColumnMenuOnRightClick = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.Size = New System.Drawing.Size(297, 338)
            Me.DataGridViewDTLeftSection_DepartmentTeams.TabIndex = 0
            Me.DataGridViewDTLeftSection_DepartmentTeams.UseEmbeddedNavigator = False
            Me.DataGridViewDTLeftSection_DepartmentTeams.ViewCaptionHeight = -1
            '
            'TabItemReportTemplatePresets_DepartmentTeamTab
            '
            Me.TabItemReportTemplatePresets_DepartmentTeamTab.AttachedControl = Me.TabControlPanelDepartmentTeamTab_DepartmentTeam
            Me.TabItemReportTemplatePresets_DepartmentTeamTab.Name = "TabItemReportTemplatePresets_DepartmentTeamTab"
            Me.TabItemReportTemplatePresets_DepartmentTeamTab.Text = "Department / Teams"
            '
            'TabControlPanelOfficeTab_Office
            '
            Me.TabControlPanelOfficeTab_Office.Controls.Add(Me.PanelOffice_Office)
            Me.TabControlPanelOfficeTab_Office.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOfficeTab_Office.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOfficeTab_Office.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOfficeTab_Office.Name = "TabControlPanelOfficeTab_Office"
            Me.TabControlPanelOfficeTab_Office.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOfficeTab_Office.Size = New System.Drawing.Size(790, 346)
            Me.TabControlPanelOfficeTab_Office.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOfficeTab_Office.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOfficeTab_Office.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOfficeTab_Office.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOfficeTab_Office.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOfficeTab_Office.Style.GradientAngle = 90
            Me.TabControlPanelOfficeTab_Office.TabIndex = 0
            Me.TabControlPanelOfficeTab_Office.TabItem = Me.TabItemReportTemplatePresets_OfficeTab
            '
            'PanelOffice_Office
            '
            Me.PanelOffice_Office.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelOffice_Office.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOffice_Office.Appearance.Options.UseBackColor = True
            Me.PanelOffice_Office.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOffice_Office.Controls.Add(Me.PanelOffice_OfficeRightSection)
            Me.PanelOffice_Office.Controls.Add(Me.ExpandableSplitterOffice_OfficeLeftRightSection)
            Me.PanelOffice_Office.Controls.Add(Me.PanelOffice_OfficeLeftSection)
            Me.PanelOffice_Office.Location = New System.Drawing.Point(4, 4)
            Me.PanelOffice_Office.Name = "PanelOffice_Office"
            Me.PanelOffice_Office.Size = New System.Drawing.Size(782, 338)
            Me.PanelOffice_Office.TabIndex = 0
            '
            'PanelOffice_OfficeRightSection
            '
            Me.PanelOffice_OfficeRightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOffice_OfficeRightSection.Appearance.Options.UseBackColor = True
            Me.PanelOffice_OfficeRightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.ButtonOfficeRightSection_Add)
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.ButtonOfficeRightSection_AddAll)
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.DataGridViewOfficeRightSection_Presets)
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.ButtonOfficeRightSection_Remove)
            Me.PanelOffice_OfficeRightSection.Controls.Add(Me.ButtonOfficeRightSection_RemoveAll)
            Me.PanelOffice_OfficeRightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelOffice_OfficeRightSection.Location = New System.Drawing.Point(309, 0)
            Me.PanelOffice_OfficeRightSection.Name = "PanelOffice_OfficeRightSection"
            Me.PanelOffice_OfficeRightSection.Size = New System.Drawing.Size(473, 338)
            Me.PanelOffice_OfficeRightSection.TabIndex = 2
            '
            'ButtonOfficeRightSection_Add
            '
            Me.ButtonOfficeRightSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOfficeRightSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOfficeRightSection_Add.Location = New System.Drawing.Point(6, 0)
            Me.ButtonOfficeRightSection_Add.Name = "ButtonOfficeRightSection_Add"
            Me.ButtonOfficeRightSection_Add.SecurityEnabled = True
            Me.ButtonOfficeRightSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOfficeRightSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOfficeRightSection_Add.TabIndex = 0
            Me.ButtonOfficeRightSection_Add.Text = ">"
            '
            'ButtonOfficeRightSection_AddAll
            '
            Me.ButtonOfficeRightSection_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOfficeRightSection_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOfficeRightSection_AddAll.Location = New System.Drawing.Point(6, 26)
            Me.ButtonOfficeRightSection_AddAll.Name = "ButtonOfficeRightSection_AddAll"
            Me.ButtonOfficeRightSection_AddAll.SecurityEnabled = True
            Me.ButtonOfficeRightSection_AddAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOfficeRightSection_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOfficeRightSection_AddAll.TabIndex = 1
            Me.ButtonOfficeRightSection_AddAll.Text = ">>"
            '
            'DataGridViewOfficeRightSection_Presets
            '
            Me.DataGridViewOfficeRightSection_Presets.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOfficeRightSection_Presets.AllowDragAndDrop = False
            Me.DataGridViewOfficeRightSection_Presets.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOfficeRightSection_Presets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOfficeRightSection_Presets.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOfficeRightSection_Presets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOfficeRightSection_Presets.AutoFilterLookupColumns = False
            Me.DataGridViewOfficeRightSection_Presets.AutoloadRepositoryDatasource = True
            Me.DataGridViewOfficeRightSection_Presets.AutoUpdateViewCaption = True
            Me.DataGridViewOfficeRightSection_Presets.BackColor = System.Drawing.Color.White
            Me.DataGridViewOfficeRightSection_Presets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewOfficeRightSection_Presets.DataSource = Nothing
            Me.DataGridViewOfficeRightSection_Presets.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOfficeRightSection_Presets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOfficeRightSection_Presets.ItemDescription = ""
            Me.DataGridViewOfficeRightSection_Presets.Location = New System.Drawing.Point(87, 0)
            Me.DataGridViewOfficeRightSection_Presets.MultiSelect = True
            Me.DataGridViewOfficeRightSection_Presets.Name = "DataGridViewOfficeRightSection_Presets"
            Me.DataGridViewOfficeRightSection_Presets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOfficeRightSection_Presets.RunStandardValidation = True
            Me.DataGridViewOfficeRightSection_Presets.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOfficeRightSection_Presets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOfficeRightSection_Presets.Size = New System.Drawing.Size(386, 338)
            Me.DataGridViewOfficeRightSection_Presets.TabIndex = 4
            Me.DataGridViewOfficeRightSection_Presets.UseEmbeddedNavigator = False
            Me.DataGridViewOfficeRightSection_Presets.ViewCaptionHeight = -1
            '
            'ButtonOfficeRightSection_Remove
            '
            Me.ButtonOfficeRightSection_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOfficeRightSection_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOfficeRightSection_Remove.Location = New System.Drawing.Point(6, 52)
            Me.ButtonOfficeRightSection_Remove.Name = "ButtonOfficeRightSection_Remove"
            Me.ButtonOfficeRightSection_Remove.SecurityEnabled = True
            Me.ButtonOfficeRightSection_Remove.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOfficeRightSection_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOfficeRightSection_Remove.TabIndex = 2
            Me.ButtonOfficeRightSection_Remove.Text = "<"
            '
            'ButtonOfficeRightSection_RemoveAll
            '
            Me.ButtonOfficeRightSection_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOfficeRightSection_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOfficeRightSection_RemoveAll.Location = New System.Drawing.Point(6, 78)
            Me.ButtonOfficeRightSection_RemoveAll.Name = "ButtonOfficeRightSection_RemoveAll"
            Me.ButtonOfficeRightSection_RemoveAll.SecurityEnabled = True
            Me.ButtonOfficeRightSection_RemoveAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOfficeRightSection_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOfficeRightSection_RemoveAll.TabIndex = 3
            Me.ButtonOfficeRightSection_RemoveAll.Text = "<<"
            '
            'ExpandableSplitterOffice_OfficeLeftRightSection
            '
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.Location = New System.Drawing.Point(303, 0)
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.Name = "ExpandableSplitterOffice_OfficeLeftRightSection"
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.Size = New System.Drawing.Size(6, 338)
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.TabIndex = 1
            Me.ExpandableSplitterOffice_OfficeLeftRightSection.TabStop = False
            '
            'PanelOffice_OfficeLeftSection
            '
            Me.PanelOffice_OfficeLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelOffice_OfficeLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelOffice_OfficeLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelOffice_OfficeLeftSection.Controls.Add(Me.DataGridViewOfficeLeftSection_Offices)
            Me.PanelOffice_OfficeLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelOffice_OfficeLeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelOffice_OfficeLeftSection.Name = "PanelOffice_OfficeLeftSection"
            Me.PanelOffice_OfficeLeftSection.Size = New System.Drawing.Size(303, 338)
            Me.PanelOffice_OfficeLeftSection.TabIndex = 0
            '
            'DataGridViewOfficeLeftSection_Offices
            '
            Me.DataGridViewOfficeLeftSection_Offices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOfficeLeftSection_Offices.AllowDragAndDrop = False
            Me.DataGridViewOfficeLeftSection_Offices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOfficeLeftSection_Offices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOfficeLeftSection_Offices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOfficeLeftSection_Offices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOfficeLeftSection_Offices.AutoFilterLookupColumns = False
            Me.DataGridViewOfficeLeftSection_Offices.AutoloadRepositoryDatasource = True
            Me.DataGridViewOfficeLeftSection_Offices.AutoUpdateViewCaption = True
            Me.DataGridViewOfficeLeftSection_Offices.BackColor = System.Drawing.Color.White
            Me.DataGridViewOfficeLeftSection_Offices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewOfficeLeftSection_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOfficeLeftSection_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOfficeLeftSection_Offices.ItemDescription = ""
            Me.DataGridViewOfficeLeftSection_Offices.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewOfficeLeftSection_Offices.MultiSelect = True
            Me.DataGridViewOfficeLeftSection_Offices.Name = "DataGridViewOfficeLeftSection_Offices"
            Me.DataGridViewOfficeLeftSection_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOfficeLeftSection_Offices.RunStandardValidation = True
            Me.DataGridViewOfficeLeftSection_Offices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOfficeLeftSection_Offices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOfficeLeftSection_Offices.Size = New System.Drawing.Size(297, 338)
            Me.DataGridViewOfficeLeftSection_Offices.TabIndex = 0
            Me.DataGridViewOfficeLeftSection_Offices.UseEmbeddedNavigator = False
            Me.DataGridViewOfficeLeftSection_Offices.ViewCaptionHeight = -1
            '
            'TabItemReportTemplatePresets_OfficeTab
            '
            Me.TabItemReportTemplatePresets_OfficeTab.AttachedControl = Me.TabControlPanelOfficeTab_Office
            Me.TabItemReportTemplatePresets_OfficeTab.Name = "TabItemReportTemplatePresets_OfficeTab"
            Me.TabItemReportTemplatePresets_OfficeTab.Text = "Office"
            '
            'ButtonForm_CopyFrom
            '
            Me.ButtonForm_CopyFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_CopyFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_CopyFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_CopyFrom.Location = New System.Drawing.Point(12, 391)
            Me.ButtonForm_CopyFrom.Name = "ButtonForm_CopyFrom"
            Me.ButtonForm_CopyFrom.SecurityEnabled = True
            Me.ButtonForm_CopyFrom.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_CopyFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_CopyFrom.TabIndex = 1
            Me.ButtonForm_CopyFrom.Text = "Copy From"
            '
            'GLReportTemplatePresetsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 423)
            Me.Controls.Add(Me.ButtonForm_CopyFrom)
            Me.Controls.Add(Me.TabControlForm_OptionsPresets)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GLReportTemplatePresetsDialog"
            Me.Text = "Options / Presets"
            CType(Me.TabControlForm_OptionsPresets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_OptionsPresets.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            CType(Me.PictureOptions_UpdateCurrencyImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxOptions_Currency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputOptions_CurrencyExchangeRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelDepartmentTeamTab_DepartmentTeam.ResumeLayout(False)
            CType(Me.PanelDepartmentTeam_DepartmentTeam, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDepartmentTeam_DepartmentTeam.ResumeLayout(False)
            CType(Me.PanelDepartmentTeam_DTRightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDepartmentTeam_DTRightSection.ResumeLayout(False)
            CType(Me.PanelDepartmentTeam_DTLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDepartmentTeam_DTLeftSection.ResumeLayout(False)
            Me.TabControlPanelOfficeTab_Office.ResumeLayout(False)
            CType(Me.PanelOffice_Office, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOffice_Office.ResumeLayout(False)
            CType(Me.PanelOffice_OfficeRightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOffice_OfficeRightSection.ResumeLayout(False)
            CType(Me.PanelOffice_OfficeLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOffice_OfficeLeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_OptionsPresets As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDepartmentTeamTab_DepartmentTeam As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReportTemplatePresets_DepartmentTeamTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOfficeTab_Office As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReportTemplatePresets_OfficeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOptionsPresets_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxOptions_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelOffice_Office As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelOffice_OfficeRightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewOfficeRightSection_Presets As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterOffice_OfficeLeftRightSection As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelOffice_OfficeLeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewOfficeLeftSection_Offices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonOfficeRightSection_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOfficeRightSection_AddAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOfficeRightSection_RemoveAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOfficeRightSection_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelDepartmentTeam_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelDepartmentTeam_DTRightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonDTRightSection_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonDTRightSection_AddAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonDTRightSection_RemoveAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonDTRightSection_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewDTRightSection_Presets As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterDepartmentTeam_DTLeftRightSection As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelDepartmentTeam_DTLeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewDTLeftSection_DepartmentTeams As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonOptions_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOptions_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOptions_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewOptions_GLReportUDRs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonOptions_UserDefined As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOptions_Default As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelOptions_CustomReport As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonOptions_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxOptions_PrintColumnHeadingsOnEveryPage As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxOptions_SortRowsBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_SortRowsBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOptions_CurrencyExchangeRate As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOptions_Currency As WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputOptions_CurrencyExchangeRate As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents SearchableComboBoxOptions_Currency As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView9 As WinForm.Presentation.Controls.GridView
        Friend WithEvents PictureOptions_UpdateCurrencyImage As DevExpress.XtraEditors.PictureEdit
    End Class

End Namespace