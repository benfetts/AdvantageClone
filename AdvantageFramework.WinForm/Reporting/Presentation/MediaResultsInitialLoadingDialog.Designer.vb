Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaResultsInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
            Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
            Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaResultsInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlForm_MCS = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelOptions_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputMonthlyBroadcast_ToYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxMonthlyBroadcast_ToMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputMonthlyBroadcast_FromYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxMonthlyBroadcast_FromMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_MonthlyBroadcast = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMonthlyBroadcast_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMonthlyBroadcast_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxBroadcastDates = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ShowJobsWithNoDetails = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonForm_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxForm_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.PanelOptions_Dates = New System.Windows.Forms.Panel()
            Me.RadioButtonDates_Broadcast = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDates_Standard = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemMCS_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_MCS.SuspendLayout()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            CType(Me.NumericInputMonthlyBroadcast_ToYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputMonthlyBroadcast_FromYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOptions_Dates.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(541, 313)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 7
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(622, 313)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'TabControlForm_MCS
            '
            Me.TabControlForm_MCS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_MCS.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_MCS.CanReorderTabs = False
            Me.TabControlForm_MCS.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_MCS.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelOptionsTab_Options)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel2)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel1)
            Me.TabControlForm_MCS.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_MCS.Name = "TabControlForm_MCS"
            Me.TabControlForm_MCS.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_MCS.SelectedTabIndex = 0
            Me.TabControlForm_MCS.Size = New System.Drawing.Size(685, 295)
            Me.TabControlForm_MCS.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_MCS.TabIndex = 25
            Me.TabControlForm_MCS.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_OptionsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectClientsTab)
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_SelectBy)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.Label1)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.NumericInputMonthlyBroadcast_ToYear)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxMonthlyBroadcast_ToMonth)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.NumericInputMonthlyBroadcast_FromYear)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxMonthlyBroadcast_FromMonth)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_MonthlyBroadcast)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelMonthlyBroadcast_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelMonthlyBroadcast_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxBroadcastDates)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxForm_ShowJobsWithNoDetails)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ButtonForm_2Years)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ButtonForm_1Year)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ButtonForm_MTD)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ButtonForm_YTD)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_Criteria)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.DateTimePickerForm_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxForm_Criteria)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.DateTimePickerForm_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_Dates)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(685, 268)
            Me.TabControlPanelOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelOptionsTab_Options.TabIndex = 0
            Me.TabControlPanelOptionsTab_Options.TabItem = Me.TabItemMCS_OptionsTab
            '
            'LabelOptions_SelectBy
            '
            Me.LabelOptions_SelectBy.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_SelectBy.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_SelectBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_SelectBy.Location = New System.Drawing.Point(11, 13)
            Me.LabelOptions_SelectBy.Name = "LabelOptions_SelectBy"
            Me.LabelOptions_SelectBy.Size = New System.Drawing.Size(148, 20)
            Me.LabelOptions_SelectBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_SelectBy.TabIndex = 28
            Me.LabelOptions_SelectBy.Text = "Select By"
            Me.LabelOptions_SelectBy.Visible = False
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.Label1.BackgroundStyle.BorderBottomWidth = 1
            Me.Label1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(173, 13)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(323, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 36
            Me.Label1.Text = "Non-Broadcast"
            '
            'NumericInputMonthlyBroadcast_ToYear
            '
            Me.NumericInputMonthlyBroadcast_ToYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMonthlyBroadcast_ToYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMonthlyBroadcast_ToYear.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_ToYear.Enabled = False
            Me.NumericInputMonthlyBroadcast_ToYear.EnterMoveNextControl = True
            Me.NumericInputMonthlyBroadcast_ToYear.Location = New System.Drawing.Point(387, 169)
            Me.NumericInputMonthlyBroadcast_ToYear.Name = "NumericInputMonthlyBroadcast_ToYear"
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.IsFloatValue = False
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_ToYear.SecurityEnabled = True
            Me.NumericInputMonthlyBroadcast_ToYear.Size = New System.Drawing.Size(40, 20)
            Me.NumericInputMonthlyBroadcast_ToYear.TabIndex = 35
            '
            'ComboBoxMonthlyBroadcast_ToMonth
            '
            Me.ComboBoxMonthlyBroadcast_ToMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMonthlyBroadcast_ToMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMonthlyBroadcast_ToMonth.AutoFindItemInDataSource = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.BookmarkingEnabled = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.ClientCode = ""
            Me.ComboBoxMonthlyBroadcast_ToMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxMonthlyBroadcast_ToMonth.DisableMouseWheel = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.DisplayMember = "Value"
            Me.ComboBoxMonthlyBroadcast_ToMonth.DisplayName = ""
            Me.ComboBoxMonthlyBroadcast_ToMonth.DivisionCode = ""
            Me.ComboBoxMonthlyBroadcast_ToMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMonthlyBroadcast_ToMonth.Enabled = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMonthlyBroadcast_ToMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMonthlyBroadcast_ToMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMonthlyBroadcast_ToMonth.FocusHighlightEnabled = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.FormattingEnabled = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.ItemHeight = 14
            Me.ComboBoxMonthlyBroadcast_ToMonth.Location = New System.Drawing.Point(221, 169)
            Me.ComboBoxMonthlyBroadcast_ToMonth.Name = "ComboBoxMonthlyBroadcast_ToMonth"
            Me.ComboBoxMonthlyBroadcast_ToMonth.ReadOnly = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.SecurityEnabled = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.Size = New System.Drawing.Size(155, 20)
            Me.ComboBoxMonthlyBroadcast_ToMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMonthlyBroadcast_ToMonth.TabIndex = 34
            Me.ComboBoxMonthlyBroadcast_ToMonth.TabOnEnter = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.ValueMember = "Key"
            Me.ComboBoxMonthlyBroadcast_ToMonth.WatermarkText = "Select Month"
            '
            'NumericInputMonthlyBroadcast_FromYear
            '
            Me.NumericInputMonthlyBroadcast_FromYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMonthlyBroadcast_FromYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMonthlyBroadcast_FromYear.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_FromYear.Enabled = False
            Me.NumericInputMonthlyBroadcast_FromYear.EnterMoveNextControl = True
            Me.NumericInputMonthlyBroadcast_FromYear.Location = New System.Drawing.Point(387, 143)
            Me.NumericInputMonthlyBroadcast_FromYear.Name = "NumericInputMonthlyBroadcast_FromYear"
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.IsFloatValue = False
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_FromYear.SecurityEnabled = True
            Me.NumericInputMonthlyBroadcast_FromYear.Size = New System.Drawing.Size(40, 20)
            Me.NumericInputMonthlyBroadcast_FromYear.TabIndex = 32
            '
            'ComboBoxMonthlyBroadcast_FromMonth
            '
            Me.ComboBoxMonthlyBroadcast_FromMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMonthlyBroadcast_FromMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMonthlyBroadcast_FromMonth.AutoFindItemInDataSource = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.BookmarkingEnabled = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.ClientCode = ""
            Me.ComboBoxMonthlyBroadcast_FromMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxMonthlyBroadcast_FromMonth.DisableMouseWheel = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.DisplayMember = "Value"
            Me.ComboBoxMonthlyBroadcast_FromMonth.DisplayName = ""
            Me.ComboBoxMonthlyBroadcast_FromMonth.DivisionCode = ""
            Me.ComboBoxMonthlyBroadcast_FromMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMonthlyBroadcast_FromMonth.Enabled = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMonthlyBroadcast_FromMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMonthlyBroadcast_FromMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMonthlyBroadcast_FromMonth.FocusHighlightEnabled = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.FormattingEnabled = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.ItemHeight = 14
            Me.ComboBoxMonthlyBroadcast_FromMonth.Location = New System.Drawing.Point(221, 143)
            Me.ComboBoxMonthlyBroadcast_FromMonth.Name = "ComboBoxMonthlyBroadcast_FromMonth"
            Me.ComboBoxMonthlyBroadcast_FromMonth.ReadOnly = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.SecurityEnabled = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.Size = New System.Drawing.Size(155, 20)
            Me.ComboBoxMonthlyBroadcast_FromMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMonthlyBroadcast_FromMonth.TabIndex = 31
            Me.ComboBoxMonthlyBroadcast_FromMonth.TabOnEnter = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.ValueMember = "Key"
            Me.ComboBoxMonthlyBroadcast_FromMonth.WatermarkText = "Select Month"
            '
            'LabelOptions_MonthlyBroadcast
            '
            Me.LabelOptions_MonthlyBroadcast.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_MonthlyBroadcast.Location = New System.Drawing.Point(173, 117)
            Me.LabelOptions_MonthlyBroadcast.Name = "LabelOptions_MonthlyBroadcast"
            Me.LabelOptions_MonthlyBroadcast.Size = New System.Drawing.Size(323, 20)
            Me.LabelOptions_MonthlyBroadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_MonthlyBroadcast.TabIndex = 29
            Me.LabelOptions_MonthlyBroadcast.Text = "Broadcast Month/Year"
            '
            'LabelMonthlyBroadcast_To
            '
            Me.LabelMonthlyBroadcast_To.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelMonthlyBroadcast_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMonthlyBroadcast_To.Location = New System.Drawing.Point(173, 169)
            Me.LabelMonthlyBroadcast_To.Name = "LabelMonthlyBroadcast_To"
            Me.LabelMonthlyBroadcast_To.Size = New System.Drawing.Size(42, 20)
            Me.LabelMonthlyBroadcast_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMonthlyBroadcast_To.TabIndex = 33
            Me.LabelMonthlyBroadcast_To.Text = "To:"
            '
            'LabelMonthlyBroadcast_From
            '
            Me.LabelMonthlyBroadcast_From.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelMonthlyBroadcast_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMonthlyBroadcast_From.Location = New System.Drawing.Point(173, 143)
            Me.LabelMonthlyBroadcast_From.Name = "LabelMonthlyBroadcast_From"
            Me.LabelMonthlyBroadcast_From.Size = New System.Drawing.Size(42, 20)
            Me.LabelMonthlyBroadcast_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMonthlyBroadcast_From.TabIndex = 30
            Me.LabelMonthlyBroadcast_From.Text = "From:"
            '
            'CheckBoxBroadcastDates
            '
            Me.CheckBoxBroadcastDates.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxBroadcastDates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxBroadcastDates.CheckValue = 0
            Me.CheckBoxBroadcastDates.CheckValueChecked = 1
            Me.CheckBoxBroadcastDates.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxBroadcastDates.CheckValueUnchecked = 0
            Me.CheckBoxBroadcastDates.ChildControls = CType(resources.GetObject("CheckBoxBroadcastDates.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBroadcastDates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxBroadcastDates.Enabled = False
            Me.CheckBoxBroadcastDates.Location = New System.Drawing.Point(173, 232)
            Me.CheckBoxBroadcastDates.Name = "CheckBoxBroadcastDates"
            Me.CheckBoxBroadcastDates.OldestSibling = Nothing
            Me.CheckBoxBroadcastDates.SecurityEnabled = True
            Me.CheckBoxBroadcastDates.SiblingControls = CType(resources.GetObject("CheckBoxBroadcastDates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBroadcastDates.Size = New System.Drawing.Size(214, 20)
            Me.CheckBoxBroadcastDates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBroadcastDates.TabIndex = 26
            Me.CheckBoxBroadcastDates.TabOnEnter = True
            Me.CheckBoxBroadcastDates.Text = "Select All by Broadcast Month/Year"
            Me.CheckBoxBroadcastDates.Visible = False
            '
            'CheckBoxForm_ShowJobsWithNoDetails
            '
            Me.CheckBoxForm_ShowJobsWithNoDetails.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxForm_ShowJobsWithNoDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValue = 0
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueChecked = 1
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ShowJobsWithNoDetails.CheckValueUnchecked = 0
            Me.CheckBoxForm_ShowJobsWithNoDetails.ChildControls = CType(resources.GetObject("CheckBoxForm_ShowJobsWithNoDetails.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsWithNoDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowJobsWithNoDetails.Location = New System.Drawing.Point(173, 206)
            Me.CheckBoxForm_ShowJobsWithNoDetails.Name = "CheckBoxForm_ShowJobsWithNoDetails"
            Me.CheckBoxForm_ShowJobsWithNoDetails.OldestSibling = Nothing
            Me.CheckBoxForm_ShowJobsWithNoDetails.SecurityEnabled = True
            Me.CheckBoxForm_ShowJobsWithNoDetails.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowJobsWithNoDetails.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsWithNoDetails.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxForm_ShowJobsWithNoDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowJobsWithNoDetails.TabIndex = 23
            Me.CheckBoxForm_ShowJobsWithNoDetails.TabOnEnter = True
            Me.CheckBoxForm_ShowJobsWithNoDetails.Text = "Show Jobs With No Details"
            Me.CheckBoxForm_ShowJobsWithNoDetails.Visible = False
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(435, 91)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 22
            Me.ButtonForm_2Years.Text = "2 Years"
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(435, 65)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 20
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(354, 91)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 21
            Me.ButtonForm_MTD.Text = "MTD"
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(354, 65)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 19
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(173, 91)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 17
            Me.LabelForm_To.Text = "To:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(173, 65)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 15
            Me.LabelForm_From.Text = "From:"
            '
            'LabelForm_Criteria
            '
            Me.LabelForm_Criteria.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_Criteria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Criteria.Location = New System.Drawing.Point(173, 39)
            Me.LabelForm_Criteria.Name = "LabelForm_Criteria"
            Me.LabelForm_Criteria.Size = New System.Drawing.Size(45, 20)
            Me.LabelForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Criteria.TabIndex = 13
            Me.LabelForm_Criteria.Text = "Criteria:"
            '
            'DateTimePickerForm_To
            '
            Me.DateTimePickerForm_To.AllowEmptyState = False
            Me.DateTimePickerForm_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_To.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_To.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_To.DisplayName = ""
            Me.DateTimePickerForm_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_To.FocusHighlightEnabled = True
            Me.DateTimePickerForm_To.FreeTextEntryMode = True
            Me.DateTimePickerForm_To.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(224, 91)
            Me.DateTimePickerForm_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_To.Name = "DateTimePickerForm_To"
            Me.DateTimePickerForm_To.ReadOnly = False
            Me.DateTimePickerForm_To.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_To.TabIndex = 18
            Me.DateTimePickerForm_To.TabOnEnter = True
            Me.DateTimePickerForm_To.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'ComboBoxForm_Criteria
            '
            Me.ComboBoxForm_Criteria.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Criteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Criteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Criteria.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Criteria.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Criteria.BookmarkingEnabled = False
            Me.ComboBoxForm_Criteria.ClientCode = ""
            Me.ComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Criteria.DisableMouseWheel = False
            Me.ComboBoxForm_Criteria.DisplayMember = "Name"
            Me.ComboBoxForm_Criteria.DisplayName = ""
            Me.ComboBoxForm_Criteria.DivisionCode = ""
            Me.ComboBoxForm_Criteria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Criteria.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Criteria.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Criteria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Criteria.FocusHighlightEnabled = True
            Me.ComboBoxForm_Criteria.FormattingEnabled = True
            Me.ComboBoxForm_Criteria.ItemHeight = 14
            Me.ComboBoxForm_Criteria.Location = New System.Drawing.Point(224, 39)
            Me.ComboBoxForm_Criteria.Name = "ComboBoxForm_Criteria"
            Me.ComboBoxForm_Criteria.ReadOnly = False
            Me.ComboBoxForm_Criteria.SecurityEnabled = True
            Me.ComboBoxForm_Criteria.Size = New System.Drawing.Size(286, 20)
            Me.ComboBoxForm_Criteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Criteria.TabIndex = 14
            Me.ComboBoxForm_Criteria.TabOnEnter = True
            Me.ComboBoxForm_Criteria.ValueMember = "Value"
            Me.ComboBoxForm_Criteria.WatermarkText = "Select"
            '
            'DateTimePickerForm_From
            '
            Me.DateTimePickerForm_From.AllowEmptyState = False
            Me.DateTimePickerForm_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_From.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_From.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_From.DisplayName = ""
            Me.DateTimePickerForm_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_From.FocusHighlightEnabled = True
            Me.DateTimePickerForm_From.FreeTextEntryMode = True
            Me.DateTimePickerForm_From.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(224, 65)
            Me.DateTimePickerForm_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.DisplayMonth = New Date(2012, 7, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_From.Name = "DateTimePickerForm_From"
            Me.DateTimePickerForm_From.ReadOnly = False
            Me.DateTimePickerForm_From.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_From.TabIndex = 16
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'PanelOptions_Dates
            '
            Me.PanelOptions_Dates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelOptions_Dates.BackColor = System.Drawing.Color.Transparent
            Me.PanelOptions_Dates.Controls.Add(Me.RadioButtonDates_Broadcast)
            Me.PanelOptions_Dates.Controls.Add(Me.RadioButtonDates_Standard)
            Me.PanelOptions_Dates.Location = New System.Drawing.Point(7, 42)
            Me.PanelOptions_Dates.Name = "PanelOptions_Dates"
            Me.PanelOptions_Dates.Size = New System.Drawing.Size(152, 53)
            Me.PanelOptions_Dates.TabIndex = 27
            Me.PanelOptions_Dates.Visible = False
            '
            'RadioButtonDates_Broadcast
            '
            Me.RadioButtonDates_Broadcast.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonDates_Broadcast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDates_Broadcast.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDates_Broadcast.Location = New System.Drawing.Point(2, 25)
            Me.RadioButtonDates_Broadcast.Name = "RadioButtonDates_Broadcast"
            Me.RadioButtonDates_Broadcast.SecurityEnabled = True
            Me.RadioButtonDates_Broadcast.Size = New System.Drawing.Size(138, 21)
            Me.RadioButtonDates_Broadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDates_Broadcast.TabIndex = 1
            Me.RadioButtonDates_Broadcast.TabOnEnter = True
            Me.RadioButtonDates_Broadcast.TabStop = False
            Me.RadioButtonDates_Broadcast.Text = "Broadcast Month/Year"
            '
            'RadioButtonDates_Standard
            '
            Me.RadioButtonDates_Standard.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonDates_Standard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDates_Standard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDates_Standard.Checked = True
            Me.RadioButtonDates_Standard.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonDates_Standard.CheckValue = "Y"
            Me.RadioButtonDates_Standard.Location = New System.Drawing.Point(3, 3)
            Me.RadioButtonDates_Standard.Name = "RadioButtonDates_Standard"
            Me.RadioButtonDates_Standard.SecurityEnabled = True
            Me.RadioButtonDates_Standard.Size = New System.Drawing.Size(131, 20)
            Me.RadioButtonDates_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDates_Standard.TabIndex = 0
            Me.RadioButtonDates_Standard.TabOnEnter = True
            Me.RadioButtonDates_Standard.Text = "Standard"
            '
            'TabItemMCS_OptionsTab
            '
            Me.TabItemMCS_OptionsTab.AttachedControl = Me.TabControlPanelOptionsTab_Options
            Me.TabItemMCS_OptionsTab.Name = "TabItemMCS_OptionsTab"
            Me.TabItemMCS_OptionsTab.Text = "Options"
            '
            'TabControlPanel2
            '
            Me.TabControlPanel2.Controls.Add(Me.CDPChooserControlSelectClients_SelectClients)
            Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel2.Name = "TabControlPanel2"
            Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel2.Size = New System.Drawing.Size(685, 268)
            Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel2.Style.GradientAngle = 90
            Me.TabControlPanel2.TabIndex = 8
            Me.TabControlPanel2.TabItem = Me.TabItemMCS_SelectClientsTab
            '
            'CDPChooserControlSelectClients_SelectClients
            '
            Me.CDPChooserControlSelectClients_SelectClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControlSelectClients_SelectClients.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControlSelectClients_SelectClients.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControlSelectClients_SelectClients.Name = "CDPChooserControlSelectClients_SelectClients"
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(677, 260)
            Me.CDPChooserControlSelectClients_SelectClients.TabIndex = 2
            '
            'TabItemMCS_SelectClientsTab
            '
            Me.TabItemMCS_SelectClientsTab.AttachedControl = Me.TabControlPanel2
            Me.TabItemMCS_SelectClientsTab.Name = "TabItemMCS_SelectClientsTab"
            Me.TabItemMCS_SelectClientsTab.Text = "Select C/D/P"
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.DataGridViewSelectOffices_Offices)
            Me.TabControlPanel1.Controls.Add(Me.RadioButtonSelectOffices_ChooseOffices)
            Me.TabControlPanel1.Controls.Add(Me.RadioButtonSelectOffices_AllOffices)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(685, 268)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 4
            Me.TabControlPanel1.TabItem = Me.TabItemJDA_SelectOfficesTab
            '
            'DataGridViewSelectOffices_Offices
            '
            Me.DataGridViewSelectOffices_Offices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectOffices_Offices.AllowDragAndDrop = False
            Me.DataGridViewSelectOffices_Offices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectOffices_Offices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectOffices_Offices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectOffices_Offices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectOffices_Offices.AutoFilterLookupColumns = False
            Me.DataGridViewSelectOffices_Offices.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectOffices_Offices.AutoUpdateViewCaption = True
            Me.DataGridViewSelectOffices_Offices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectOffices_Offices.DataSource = Nothing
            Me.DataGridViewSelectOffices_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOffices_Offices.Enabled = False
            Me.DataGridViewSelectOffices_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOffices_Offices.ItemDescription = "Office(s)"
            Me.DataGridViewSelectOffices_Offices.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectOffices_Offices.MultiSelect = False
            Me.DataGridViewSelectOffices_Offices.Name = "DataGridViewSelectOffices_Offices"
            Me.DataGridViewSelectOffices_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectOffices_Offices.RunStandardValidation = True
            Me.DataGridViewSelectOffices_Offices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(677, 234)
            Me.DataGridViewSelectOffices_Offices.TabIndex = 3
            Me.DataGridViewSelectOffices_Offices.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOffices_Offices.ViewCaptionHeight = -1
            '
            'RadioButtonSelectOffices_ChooseOffices
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_ChooseOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_ChooseOffices.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectOffices_ChooseOffices.Name = "RadioButtonSelectOffices_ChooseOffices"
            Me.RadioButtonSelectOffices_ChooseOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_ChooseOffices.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectOffices_ChooseOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_ChooseOffices.TabIndex = 2
            Me.RadioButtonSelectOffices_ChooseOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_ChooseOffices.TabStop = False
            Me.RadioButtonSelectOffices_ChooseOffices.Text = "Choose Offices"
            '
            'RadioButtonSelectOffices_AllOffices
            '
            Me.RadioButtonSelectOffices_AllOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_AllOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_AllOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_AllOffices.Checked = True
            Me.RadioButtonSelectOffices_AllOffices.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectOffices_AllOffices.CheckValue = "Y"
            Me.RadioButtonSelectOffices_AllOffices.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectOffices_AllOffices.Name = "RadioButtonSelectOffices_AllOffices"
            Me.RadioButtonSelectOffices_AllOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_AllOffices.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectOffices_AllOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_AllOffices.TabIndex = 1
            Me.RadioButtonSelectOffices_AllOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_AllOffices.Text = "All Offices"
            '
            'TabItemJDA_SelectOfficesTab
            '
            Me.TabItemJDA_SelectOfficesTab.AttachedControl = Me.TabControlPanel1
            Me.TabItemJDA_SelectOfficesTab.Name = "TabItemJDA_SelectOfficesTab"
            Me.TabItemJDA_SelectOfficesTab.Text = "Select Offices"
            '
            'MediaResultsInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(709, 345)
            Me.Controls.Add(Me.TabControlForm_MCS)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaResultsInitialLoadingDialog"
            Me.Text = "Media Results Initial Criteria"
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_MCS.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            CType(Me.NumericInputMonthlyBroadcast_ToYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputMonthlyBroadcast_FromYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOptions_Dates.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_MCS As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemMCS_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_AllOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMCS_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxForm_ShowJobsWithNoDetails As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonForm_2Years As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_1Year As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MTD As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_YTD As WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_From As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Criteria As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_To As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBoxForm_Criteria As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DateTimePickerForm_From As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents CheckBoxBroadcastDates As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelOptions_SelectBy As WinForm.Presentation.Controls.Label
        Friend WithEvents PanelOptions_Dates As Windows.Forms.Panel
        Friend WithEvents RadioButtonDates_Standard As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDates_Broadcast As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents NumericInputMonthlyBroadcast_ToYear As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxMonthlyBroadcast_ToMonth As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputMonthlyBroadcast_FromYear As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxMonthlyBroadcast_FromMonth As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_MonthlyBroadcast As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMonthlyBroadcast_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMonthlyBroadcast_From As WinForm.Presentation.Controls.Label
        Friend WithEvents Label1 As WinForm.Presentation.Controls.Label
    End Class

End Namespace