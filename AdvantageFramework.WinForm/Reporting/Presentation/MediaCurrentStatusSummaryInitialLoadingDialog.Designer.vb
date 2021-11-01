Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaCurrentStatusSummaryInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaCurrentStatusSummaryInitialLoadingDialog))
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
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlForm_MCS = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelOptions_SelectBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_Dates = New System.Windows.Forms.Panel()
            Me.RadioButtonDates_Standard = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDates_Broadcast = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxBroadcastDates = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputMonthlyBroadcast_ToYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.DateTimePickerNonDailyBroadcast_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxMonthlyBroadcast_ToMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputMonthlyBroadcast_FromYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.DateTimePickerNonDailyBroadcast_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxMonthlyBroadcast_FromMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_MonthlyBroadcast = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNonDailyBroadcast_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNonDailyBroadcast_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOptions_NonDailyBroadcast = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMonthlyBroadcast_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_MediaTypes = New System.Windows.Forms.Panel()
            Me.CheckBoxMediaTypes_Television = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Internet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Radio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_All = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelMonthlyBroadcast_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOptions_MediaTypes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_Include = New System.Windows.Forms.Panel()
            Me.RadioButtonInclude_OpenOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonInclude_OpenAndClosed = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemMCS_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemMCS_SelectCDPTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectVendorsTab_SelectVendors = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectVendors_Vendors = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectVendors_AllVendors = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectVendors_ChooseVendors = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectVendorsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectMarkets_Markets = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectMarkets_AllMarkets = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectMarkets_ChooseMarkets = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectMarketsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_MCS.SuspendLayout()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            Me.PanelOptions_Dates.SuspendLayout()
            CType(Me.NumericInputMonthlyBroadcast_ToYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerNonDailyBroadcast_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputMonthlyBroadcast_FromYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerNonDailyBroadcast_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOptions_MediaTypes.SuspendLayout()
            Me.PanelOptions_Include.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.TabControlPanelSelectVendorsTab_SelectVendors.SuspendLayout()
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(682, 477)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 1
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(763, 477)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 2
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
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelSelectMarketsTab_SelectMarkets)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelSelectVendorsTab_SelectVendors)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelOptionsTab_Options)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel2)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel1)
            Me.TabControlForm_MCS.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_MCS.Name = "TabControlForm_MCS"
            Me.TabControlForm_MCS.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_MCS.SelectedTabIndex = 0
            Me.TabControlForm_MCS.Size = New System.Drawing.Size(826, 459)
            Me.TabControlForm_MCS.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_MCS.TabIndex = 0
            Me.TabControlForm_MCS.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_OptionsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectOfficesTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectCDPTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectVendorsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectMarketsTab)
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_SelectBy)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_Dates)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxBroadcastDates)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.NumericInputMonthlyBroadcast_ToYear)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.DateTimePickerNonDailyBroadcast_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxMonthlyBroadcast_ToMonth)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.NumericInputMonthlyBroadcast_FromYear)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.DateTimePickerNonDailyBroadcast_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxMonthlyBroadcast_FromMonth)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_MonthlyBroadcast)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelNonDailyBroadcast_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelNonDailyBroadcast_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_NonDailyBroadcast)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelMonthlyBroadcast_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_MediaTypes)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelMonthlyBroadcast_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_MediaTypes)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_Include)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_Include)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(826, 432)
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
            Me.LabelOptions_SelectBy.BackColor = System.Drawing.Color.White
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
            Me.LabelOptions_SelectBy.Location = New System.Drawing.Point(3, 97)
            Me.LabelOptions_SelectBy.Name = "LabelOptions_SelectBy"
            Me.LabelOptions_SelectBy.Size = New System.Drawing.Size(148, 20)
            Me.LabelOptions_SelectBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_SelectBy.TabIndex = 19
            Me.LabelOptions_SelectBy.Text = "Select By"
            '
            'PanelOptions_Dates
            '
            Me.PanelOptions_Dates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelOptions_Dates.BackColor = System.Drawing.Color.White
            Me.PanelOptions_Dates.Controls.Add(Me.RadioButtonDates_Standard)
            Me.PanelOptions_Dates.Controls.Add(Me.RadioButtonDates_Broadcast)
            Me.PanelOptions_Dates.Location = New System.Drawing.Point(4, 123)
            Me.PanelOptions_Dates.Name = "PanelOptions_Dates"
            Me.PanelOptions_Dates.Size = New System.Drawing.Size(152, 53)
            Me.PanelOptions_Dates.TabIndex = 2
            '
            'RadioButtonDates_Standard
            '
            Me.RadioButtonDates_Standard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDates_Standard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDates_Standard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDates_Standard.Checked = True
            Me.RadioButtonDates_Standard.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonDates_Standard.CheckValue = "Y"
            Me.RadioButtonDates_Standard.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonDates_Standard.Name = "RadioButtonDates_Standard"
            Me.RadioButtonDates_Standard.SecurityEnabled = True
            Me.RadioButtonDates_Standard.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonDates_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDates_Standard.TabIndex = 0
            Me.RadioButtonDates_Standard.TabOnEnter = True
            Me.RadioButtonDates_Standard.Text = "Standard"
            '
            'RadioButtonDates_Broadcast
            '
            Me.RadioButtonDates_Broadcast.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDates_Broadcast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDates_Broadcast.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDates_Broadcast.Location = New System.Drawing.Point(0, 26)
            Me.RadioButtonDates_Broadcast.Name = "RadioButtonDates_Broadcast"
            Me.RadioButtonDates_Broadcast.SecurityEnabled = True
            Me.RadioButtonDates_Broadcast.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonDates_Broadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDates_Broadcast.TabIndex = 1
            Me.RadioButtonDates_Broadcast.TabOnEnter = True
            Me.RadioButtonDates_Broadcast.TabStop = False
            Me.RadioButtonDates_Broadcast.Text = "Broadcast Month/Year"
            '
            'CheckBoxBroadcastDates
            '
            Me.CheckBoxBroadcastDates.BackColor = System.Drawing.Color.White
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
            Me.CheckBoxBroadcastDates.Location = New System.Drawing.Point(316, 186)
            Me.CheckBoxBroadcastDates.Name = "CheckBoxBroadcastDates"
            Me.CheckBoxBroadcastDates.OldestSibling = Nothing
            Me.CheckBoxBroadcastDates.SecurityEnabled = True
            Me.CheckBoxBroadcastDates.SiblingControls = CType(resources.GetObject("CheckBoxBroadcastDates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBroadcastDates.Size = New System.Drawing.Size(219, 20)
            Me.CheckBoxBroadcastDates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBroadcastDates.TabIndex = 18
            Me.CheckBoxBroadcastDates.TabOnEnter = True
            Me.CheckBoxBroadcastDates.Text = "Select All by Broadcast Month/Year"
            Me.CheckBoxBroadcastDates.Visible = False
            '
            'NumericInputMonthlyBroadcast_ToYear
            '
            Me.NumericInputMonthlyBroadcast_ToYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMonthlyBroadcast_ToYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMonthlyBroadcast_ToYear.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_ToYear.EnterMoveNextControl = True
            Me.NumericInputMonthlyBroadcast_ToYear.Location = New System.Drawing.Point(525, 56)
            Me.NumericInputMonthlyBroadcast_ToYear.Name = "NumericInputMonthlyBroadcast_ToYear"
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.DisplayFormat.FormatString = "d4"
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.IsFloatValue = False
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.Mask.EditMask = "d4"
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.MaxLength = 11
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_ToYear.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_ToYear.SecurityEnabled = True
            Me.NumericInputMonthlyBroadcast_ToYear.Size = New System.Drawing.Size(40, 20)
            Me.NumericInputMonthlyBroadcast_ToYear.TabIndex = 17
            '
            'DateTimePickerNonDailyBroadcast_To
            '
            Me.DateTimePickerNonDailyBroadcast_To.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerNonDailyBroadcast_To.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerNonDailyBroadcast_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonDailyBroadcast_To.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerNonDailyBroadcast_To.ButtonDropDown.Visible = True
            Me.DateTimePickerNonDailyBroadcast_To.ButtonFreeText.Checked = True
            Me.DateTimePickerNonDailyBroadcast_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerNonDailyBroadcast_To.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerNonDailyBroadcast_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNonDailyBroadcast_To.DisplayName = ""
            Me.DateTimePickerNonDailyBroadcast_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNonDailyBroadcast_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNonDailyBroadcast_To.FocusHighlightEnabled = True
            Me.DateTimePickerNonDailyBroadcast_To.FreeTextEntryMode = True
            Me.DateTimePickerNonDailyBroadcast_To.IsPopupCalendarOpen = False
            Me.DateTimePickerNonDailyBroadcast_To.Location = New System.Drawing.Point(364, 149)
            Me.DateTimePickerNonDailyBroadcast_To.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerNonDailyBroadcast_To.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.DisplayMonth = New Date(2013, 4, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonDailyBroadcast_To.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerNonDailyBroadcast_To.Name = "DateTimePickerNonDailyBroadcast_To"
            Me.DateTimePickerNonDailyBroadcast_To.ReadOnly = False
            Me.DateTimePickerNonDailyBroadcast_To.Size = New System.Drawing.Size(155, 20)
            Me.DateTimePickerNonDailyBroadcast_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNonDailyBroadcast_To.TabIndex = 8
            Me.DateTimePickerNonDailyBroadcast_To.TabOnEnter = True
            Me.DateTimePickerNonDailyBroadcast_To.Value = New Date(2013, 4, 23, 10, 26, 41, 182)
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
            Me.ComboBoxMonthlyBroadcast_ToMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMonthlyBroadcast_ToMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMonthlyBroadcast_ToMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMonthlyBroadcast_ToMonth.FocusHighlightEnabled = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.FormattingEnabled = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.ItemHeight = 14
            Me.ComboBoxMonthlyBroadcast_ToMonth.Location = New System.Drawing.Point(364, 56)
            Me.ComboBoxMonthlyBroadcast_ToMonth.Name = "ComboBoxMonthlyBroadcast_ToMonth"
            Me.ComboBoxMonthlyBroadcast_ToMonth.ReadOnly = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.SecurityEnabled = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.Size = New System.Drawing.Size(155, 20)
            Me.ComboBoxMonthlyBroadcast_ToMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMonthlyBroadcast_ToMonth.TabIndex = 16
            Me.ComboBoxMonthlyBroadcast_ToMonth.TabOnEnter = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.ValueMember = "Key"
            Me.ComboBoxMonthlyBroadcast_ToMonth.WatermarkText = "Select Month"
            '
            'NumericInputMonthlyBroadcast_FromYear
            '
            Me.NumericInputMonthlyBroadcast_FromYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMonthlyBroadcast_FromYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMonthlyBroadcast_FromYear.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_FromYear.EnterMoveNextControl = True
            Me.NumericInputMonthlyBroadcast_FromYear.Location = New System.Drawing.Point(525, 30)
            Me.NumericInputMonthlyBroadcast_FromYear.Name = "NumericInputMonthlyBroadcast_FromYear"
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.DisplayFormat.FormatString = "d4"
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.IsFloatValue = False
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.Mask.EditMask = "d4"
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.MaxLength = 11
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_FromYear.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_FromYear.SecurityEnabled = True
            Me.NumericInputMonthlyBroadcast_FromYear.Size = New System.Drawing.Size(40, 20)
            Me.NumericInputMonthlyBroadcast_FromYear.TabIndex = 14
            '
            'DateTimePickerNonDailyBroadcast_From
            '
            Me.DateTimePickerNonDailyBroadcast_From.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerNonDailyBroadcast_From.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerNonDailyBroadcast_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonDailyBroadcast_From.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerNonDailyBroadcast_From.ButtonDropDown.Visible = True
            Me.DateTimePickerNonDailyBroadcast_From.ButtonFreeText.Checked = True
            Me.DateTimePickerNonDailyBroadcast_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerNonDailyBroadcast_From.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerNonDailyBroadcast_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNonDailyBroadcast_From.DisplayName = ""
            Me.DateTimePickerNonDailyBroadcast_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNonDailyBroadcast_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNonDailyBroadcast_From.FocusHighlightEnabled = True
            Me.DateTimePickerNonDailyBroadcast_From.FreeTextEntryMode = True
            Me.DateTimePickerNonDailyBroadcast_From.IsPopupCalendarOpen = False
            Me.DateTimePickerNonDailyBroadcast_From.Location = New System.Drawing.Point(364, 123)
            Me.DateTimePickerNonDailyBroadcast_From.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerNonDailyBroadcast_From.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.DisplayMonth = New Date(2013, 4, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerNonDailyBroadcast_From.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerNonDailyBroadcast_From.Name = "DateTimePickerNonDailyBroadcast_From"
            Me.DateTimePickerNonDailyBroadcast_From.ReadOnly = False
            Me.DateTimePickerNonDailyBroadcast_From.Size = New System.Drawing.Size(155, 20)
            Me.DateTimePickerNonDailyBroadcast_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNonDailyBroadcast_From.TabIndex = 6
            Me.DateTimePickerNonDailyBroadcast_From.TabOnEnter = True
            Me.DateTimePickerNonDailyBroadcast_From.Value = New Date(2013, 4, 23, 10, 26, 45, 244)
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
            Me.ComboBoxMonthlyBroadcast_FromMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMonthlyBroadcast_FromMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMonthlyBroadcast_FromMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMonthlyBroadcast_FromMonth.FocusHighlightEnabled = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.FormattingEnabled = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.ItemHeight = 14
            Me.ComboBoxMonthlyBroadcast_FromMonth.Location = New System.Drawing.Point(364, 30)
            Me.ComboBoxMonthlyBroadcast_FromMonth.Name = "ComboBoxMonthlyBroadcast_FromMonth"
            Me.ComboBoxMonthlyBroadcast_FromMonth.ReadOnly = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.SecurityEnabled = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.Size = New System.Drawing.Size(155, 20)
            Me.ComboBoxMonthlyBroadcast_FromMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMonthlyBroadcast_FromMonth.TabIndex = 13
            Me.ComboBoxMonthlyBroadcast_FromMonth.TabOnEnter = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.ValueMember = "Key"
            Me.ComboBoxMonthlyBroadcast_FromMonth.WatermarkText = "Select Month"
            '
            'LabelOptions_MonthlyBroadcast
            '
            Me.LabelOptions_MonthlyBroadcast.BackColor = System.Drawing.Color.White
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
            Me.LabelOptions_MonthlyBroadcast.Location = New System.Drawing.Point(316, 4)
            Me.LabelOptions_MonthlyBroadcast.Name = "LabelOptions_MonthlyBroadcast"
            Me.LabelOptions_MonthlyBroadcast.Size = New System.Drawing.Size(308, 20)
            Me.LabelOptions_MonthlyBroadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_MonthlyBroadcast.TabIndex = 9
            Me.LabelOptions_MonthlyBroadcast.Text = "Broadcast Month/Year"
            '
            'LabelNonDailyBroadcast_To
            '
            Me.LabelNonDailyBroadcast_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNonDailyBroadcast_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNonDailyBroadcast_To.Location = New System.Drawing.Point(316, 149)
            Me.LabelNonDailyBroadcast_To.Name = "LabelNonDailyBroadcast_To"
            Me.LabelNonDailyBroadcast_To.Size = New System.Drawing.Size(42, 20)
            Me.LabelNonDailyBroadcast_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNonDailyBroadcast_To.TabIndex = 7
            Me.LabelNonDailyBroadcast_To.Text = "To:"
            '
            'LabelNonDailyBroadcast_From
            '
            Me.LabelNonDailyBroadcast_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNonDailyBroadcast_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNonDailyBroadcast_From.Location = New System.Drawing.Point(316, 123)
            Me.LabelNonDailyBroadcast_From.Name = "LabelNonDailyBroadcast_From"
            Me.LabelNonDailyBroadcast_From.Size = New System.Drawing.Size(42, 20)
            Me.LabelNonDailyBroadcast_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNonDailyBroadcast_From.TabIndex = 5
            Me.LabelNonDailyBroadcast_From.Text = "From:"
            '
            'LabelOptions_NonDailyBroadcast
            '
            Me.LabelOptions_NonDailyBroadcast.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_NonDailyBroadcast.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_NonDailyBroadcast.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_NonDailyBroadcast.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_NonDailyBroadcast.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_NonDailyBroadcast.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_NonDailyBroadcast.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_NonDailyBroadcast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_NonDailyBroadcast.Location = New System.Drawing.Point(316, 97)
            Me.LabelOptions_NonDailyBroadcast.Name = "LabelOptions_NonDailyBroadcast"
            Me.LabelOptions_NonDailyBroadcast.Size = New System.Drawing.Size(308, 20)
            Me.LabelOptions_NonDailyBroadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_NonDailyBroadcast.TabIndex = 4
            Me.LabelOptions_NonDailyBroadcast.Text = "Non-Broadcast"
            '
            'LabelMonthlyBroadcast_To
            '
            Me.LabelMonthlyBroadcast_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMonthlyBroadcast_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMonthlyBroadcast_To.Location = New System.Drawing.Point(316, 56)
            Me.LabelMonthlyBroadcast_To.Name = "LabelMonthlyBroadcast_To"
            Me.LabelMonthlyBroadcast_To.Size = New System.Drawing.Size(42, 20)
            Me.LabelMonthlyBroadcast_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMonthlyBroadcast_To.TabIndex = 15
            Me.LabelMonthlyBroadcast_To.Text = "To:"
            '
            'PanelOptions_MediaTypes
            '
            Me.PanelOptions_MediaTypes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelOptions_MediaTypes.BackColor = System.Drawing.Color.White
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Television)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_OutOfHome)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Internet)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Radio)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Newspaper)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Magazine)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_All)
            Me.PanelOptions_MediaTypes.Location = New System.Drawing.Point(158, 30)
            Me.PanelOptions_MediaTypes.Name = "PanelOptions_MediaTypes"
            Me.PanelOptions_MediaTypes.Size = New System.Drawing.Size(152, 219)
            Me.PanelOptions_MediaTypes.TabIndex = 3
            '
            'CheckBoxMediaTypes_Television
            '
            Me.CheckBoxMediaTypes_Television.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaTypes_Television.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Television.CheckValue = 0
            Me.CheckBoxMediaTypes_Television.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Television.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Television.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Television.ChildControls = Nothing
            Me.CheckBoxMediaTypes_Television.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Television.Enabled = False
            Me.CheckBoxMediaTypes_Television.Location = New System.Drawing.Point(0, 156)
            Me.CheckBoxMediaTypes_Television.Name = "CheckBoxMediaTypes_Television"
            Me.CheckBoxMediaTypes_Television.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Television.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Television.SiblingControls = Nothing
            Me.CheckBoxMediaTypes_Television.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxMediaTypes_Television.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Television.TabIndex = 6
            Me.CheckBoxMediaTypes_Television.TabOnEnter = True
            Me.CheckBoxMediaTypes_Television.Text = "Television"
            '
            'CheckBoxMediaTypes_OutOfHome
            '
            Me.CheckBoxMediaTypes_OutOfHome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaTypes_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_OutOfHome.CheckValue = 0
            Me.CheckBoxMediaTypes_OutOfHome.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_OutOfHome.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_OutOfHome.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_OutOfHome.ChildControls = Nothing
            Me.CheckBoxMediaTypes_OutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_OutOfHome.Enabled = False
            Me.CheckBoxMediaTypes_OutOfHome.Location = New System.Drawing.Point(0, 104)
            Me.CheckBoxMediaTypes_OutOfHome.Name = "CheckBoxMediaTypes_OutOfHome"
            Me.CheckBoxMediaTypes_OutOfHome.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_OutOfHome.SecurityEnabled = True
            Me.CheckBoxMediaTypes_OutOfHome.SiblingControls = Nothing
            Me.CheckBoxMediaTypes_OutOfHome.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxMediaTypes_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_OutOfHome.TabIndex = 4
            Me.CheckBoxMediaTypes_OutOfHome.TabOnEnter = True
            Me.CheckBoxMediaTypes_OutOfHome.Text = "Out of Home"
            '
            'CheckBoxMediaTypes_Internet
            '
            Me.CheckBoxMediaTypes_Internet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaTypes_Internet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Internet.CheckValue = 0
            Me.CheckBoxMediaTypes_Internet.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Internet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Internet.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Internet.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_Internet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Internet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Internet.Enabled = False
            Me.CheckBoxMediaTypes_Internet.Location = New System.Drawing.Point(0, 26)
            Me.CheckBoxMediaTypes_Internet.Name = "CheckBoxMediaTypes_Internet"
            Me.CheckBoxMediaTypes_Internet.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Internet.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Internet.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_Internet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_Internet.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxMediaTypes_Internet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Internet.TabIndex = 1
            Me.CheckBoxMediaTypes_Internet.TabOnEnter = True
            Me.CheckBoxMediaTypes_Internet.Text = "Internet"
            '
            'CheckBoxMediaTypes_Radio
            '
            Me.CheckBoxMediaTypes_Radio.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaTypes_Radio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Radio.CheckValue = 0
            Me.CheckBoxMediaTypes_Radio.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Radio.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Radio.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Radio.ChildControls = Nothing
            Me.CheckBoxMediaTypes_Radio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Radio.Enabled = False
            Me.CheckBoxMediaTypes_Radio.Location = New System.Drawing.Point(0, 130)
            Me.CheckBoxMediaTypes_Radio.Name = "CheckBoxMediaTypes_Radio"
            Me.CheckBoxMediaTypes_Radio.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Radio.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Radio.SiblingControls = Nothing
            Me.CheckBoxMediaTypes_Radio.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxMediaTypes_Radio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Radio.TabIndex = 5
            Me.CheckBoxMediaTypes_Radio.TabOnEnter = True
            Me.CheckBoxMediaTypes_Radio.Text = "Radio"
            '
            'CheckBoxMediaTypes_Newspaper
            '
            Me.CheckBoxMediaTypes_Newspaper.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaTypes_Newspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Newspaper.CheckValue = 0
            Me.CheckBoxMediaTypes_Newspaper.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Newspaper.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Newspaper.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Newspaper.ChildControls = Nothing
            Me.CheckBoxMediaTypes_Newspaper.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Newspaper.Enabled = False
            Me.CheckBoxMediaTypes_Newspaper.Location = New System.Drawing.Point(0, 78)
            Me.CheckBoxMediaTypes_Newspaper.Name = "CheckBoxMediaTypes_Newspaper"
            Me.CheckBoxMediaTypes_Newspaper.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Newspaper.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Newspaper.SiblingControls = Nothing
            Me.CheckBoxMediaTypes_Newspaper.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxMediaTypes_Newspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Newspaper.TabIndex = 3
            Me.CheckBoxMediaTypes_Newspaper.TabOnEnter = True
            Me.CheckBoxMediaTypes_Newspaper.Text = "Newspaper"
            '
            'CheckBoxMediaTypes_Magazine
            '
            Me.CheckBoxMediaTypes_Magazine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaTypes_Magazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_Magazine.CheckValue = 0
            Me.CheckBoxMediaTypes_Magazine.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_Magazine.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_Magazine.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_Magazine.ChildControls = Nothing
            Me.CheckBoxMediaTypes_Magazine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_Magazine.Enabled = False
            Me.CheckBoxMediaTypes_Magazine.Location = New System.Drawing.Point(0, 52)
            Me.CheckBoxMediaTypes_Magazine.Name = "CheckBoxMediaTypes_Magazine"
            Me.CheckBoxMediaTypes_Magazine.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_Magazine.SecurityEnabled = True
            Me.CheckBoxMediaTypes_Magazine.SiblingControls = Nothing
            Me.CheckBoxMediaTypes_Magazine.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxMediaTypes_Magazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_Magazine.TabIndex = 2
            Me.CheckBoxMediaTypes_Magazine.TabOnEnter = True
            Me.CheckBoxMediaTypes_Magazine.Text = "Magazine"
            '
            'CheckBoxMediaTypes_All
            '
            Me.CheckBoxMediaTypes_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaTypes_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaTypes_All.CheckValue = 0
            Me.CheckBoxMediaTypes_All.CheckValueChecked = 1
            Me.CheckBoxMediaTypes_All.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMediaTypes_All.CheckValueUnchecked = 0
            Me.CheckBoxMediaTypes_All.ChildControls = CType(resources.GetObject("CheckBoxMediaTypes_All.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_All.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaTypes_All.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxMediaTypes_All.Name = "CheckBoxMediaTypes_All"
            Me.CheckBoxMediaTypes_All.OldestSibling = Nothing
            Me.CheckBoxMediaTypes_All.SecurityEnabled = True
            Me.CheckBoxMediaTypes_All.SiblingControls = CType(resources.GetObject("CheckBoxMediaTypes_All.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaTypes_All.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxMediaTypes_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaTypes_All.TabIndex = 0
            Me.CheckBoxMediaTypes_All.TabOnEnter = True
            Me.CheckBoxMediaTypes_All.Text = "All"
            '
            'LabelMonthlyBroadcast_From
            '
            Me.LabelMonthlyBroadcast_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMonthlyBroadcast_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMonthlyBroadcast_From.Location = New System.Drawing.Point(316, 30)
            Me.LabelMonthlyBroadcast_From.Name = "LabelMonthlyBroadcast_From"
            Me.LabelMonthlyBroadcast_From.Size = New System.Drawing.Size(42, 20)
            Me.LabelMonthlyBroadcast_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMonthlyBroadcast_From.TabIndex = 12
            Me.LabelMonthlyBroadcast_From.Text = "From:"
            '
            'LabelOptions_MediaTypes
            '
            Me.LabelOptions_MediaTypes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_MediaTypes.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MediaTypes.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_MediaTypes.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_MediaTypes.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MediaTypes.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MediaTypes.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MediaTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_MediaTypes.Location = New System.Drawing.Point(158, 4)
            Me.LabelOptions_MediaTypes.Name = "LabelOptions_MediaTypes"
            Me.LabelOptions_MediaTypes.Size = New System.Drawing.Size(152, 20)
            Me.LabelOptions_MediaTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_MediaTypes.TabIndex = 2
            Me.LabelOptions_MediaTypes.Text = "Media Types"
            '
            'PanelOptions_Include
            '
            Me.PanelOptions_Include.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PanelOptions_Include.BackColor = System.Drawing.Color.White
            Me.PanelOptions_Include.Controls.Add(Me.RadioButtonInclude_OpenOnly)
            Me.PanelOptions_Include.Controls.Add(Me.RadioButtonInclude_OpenAndClosed)
            Me.PanelOptions_Include.Location = New System.Drawing.Point(4, 30)
            Me.PanelOptions_Include.Name = "PanelOptions_Include"
            Me.PanelOptions_Include.Size = New System.Drawing.Size(152, 53)
            Me.PanelOptions_Include.TabIndex = 1
            '
            'RadioButtonInclude_OpenOnly
            '
            Me.RadioButtonInclude_OpenOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInclude_OpenOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInclude_OpenOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInclude_OpenOnly.Checked = True
            Me.RadioButtonInclude_OpenOnly.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonInclude_OpenOnly.CheckValue = "Y"
            Me.RadioButtonInclude_OpenOnly.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonInclude_OpenOnly.Name = "RadioButtonInclude_OpenOnly"
            Me.RadioButtonInclude_OpenOnly.SecurityEnabled = True
            Me.RadioButtonInclude_OpenOnly.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonInclude_OpenOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInclude_OpenOnly.TabIndex = 0
            Me.RadioButtonInclude_OpenOnly.TabOnEnter = True
            Me.RadioButtonInclude_OpenOnly.Text = "Open Only"
            '
            'RadioButtonInclude_OpenAndClosed
            '
            Me.RadioButtonInclude_OpenAndClosed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInclude_OpenAndClosed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInclude_OpenAndClosed.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInclude_OpenAndClosed.Location = New System.Drawing.Point(0, 26)
            Me.RadioButtonInclude_OpenAndClosed.Name = "RadioButtonInclude_OpenAndClosed"
            Me.RadioButtonInclude_OpenAndClosed.SecurityEnabled = True
            Me.RadioButtonInclude_OpenAndClosed.Size = New System.Drawing.Size(152, 20)
            Me.RadioButtonInclude_OpenAndClosed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInclude_OpenAndClosed.TabIndex = 1
            Me.RadioButtonInclude_OpenAndClosed.TabOnEnter = True
            Me.RadioButtonInclude_OpenAndClosed.TabStop = False
            Me.RadioButtonInclude_OpenAndClosed.Text = "Open And Closed"
            '
            'LabelOptions_Include
            '
            Me.LabelOptions_Include.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_Include.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_Include.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_Include.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_Include.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_Include.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_Include.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_Include.Location = New System.Drawing.Point(4, 4)
            Me.LabelOptions_Include.Name = "LabelOptions_Include"
            Me.LabelOptions_Include.Size = New System.Drawing.Size(148, 20)
            Me.LabelOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_Include.TabIndex = 0
            Me.LabelOptions_Include.Text = "Include"
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
            Me.TabControlPanel2.Size = New System.Drawing.Size(826, 432)
            Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel2.Style.GradientAngle = 90
            Me.TabControlPanel2.TabIndex = 8
            Me.TabControlPanel2.TabItem = Me.TabItemMCS_SelectCDPTab
            '
            'CDPChooserControlSelectClients_SelectClients
            '
            Me.CDPChooserControlSelectClients_SelectClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControlSelectClients_SelectClients.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControlSelectClients_SelectClients.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControlSelectClients_SelectClients.Name = "CDPChooserControlSelectClients_SelectClients"
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(818, 424)
            Me.CDPChooserControlSelectClients_SelectClients.TabIndex = 0
            '
            'TabItemMCS_SelectCDPTab
            '
            Me.TabItemMCS_SelectCDPTab.AttachedControl = Me.TabControlPanel2
            Me.TabItemMCS_SelectCDPTab.Name = "TabItemMCS_SelectCDPTab"
            Me.TabItemMCS_SelectCDPTab.Text = "Select C/D/P"
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
            Me.TabControlPanel1.Size = New System.Drawing.Size(826, 432)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 4
            Me.TabControlPanel1.TabItem = Me.TabItemMCS_SelectOfficesTab
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
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(818, 398)
            Me.DataGridViewSelectOffices_Offices.TabIndex = 6
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
            Me.RadioButtonSelectOffices_ChooseOffices.Location = New System.Drawing.Point(89, 4)
            Me.RadioButtonSelectOffices_ChooseOffices.Name = "RadioButtonSelectOffices_ChooseOffices"
            Me.RadioButtonSelectOffices_ChooseOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_ChooseOffices.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectOffices_ChooseOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_ChooseOffices.TabIndex = 5
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
            Me.RadioButtonSelectOffices_AllOffices.Location = New System.Drawing.Point(6, 4)
            Me.RadioButtonSelectOffices_AllOffices.Name = "RadioButtonSelectOffices_AllOffices"
            Me.RadioButtonSelectOffices_AllOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_AllOffices.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectOffices_AllOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_AllOffices.TabIndex = 4
            Me.RadioButtonSelectOffices_AllOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_AllOffices.Text = "All Offices"
            '
            'TabItemMCS_SelectOfficesTab
            '
            Me.TabItemMCS_SelectOfficesTab.AttachedControl = Me.TabControlPanel1
            Me.TabItemMCS_SelectOfficesTab.Name = "TabItemMCS_SelectOfficesTab"
            Me.TabItemMCS_SelectOfficesTab.Text = "Select Offices"
            '
            'TabControlPanelSelectVendorsTab_SelectVendors
            '
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Controls.Add(Me.DataGridViewSelectVendors_Vendors)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Controls.Add(Me.RadioButtonSelectVendors_AllVendors)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Controls.Add(Me.RadioButtonSelectVendors_ChooseVendors)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Name = "TabControlPanelSelectVendorsTab_SelectVendors"
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Size = New System.Drawing.Size(685, 313)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Style.GradientAngle = 90
            Me.TabControlPanelSelectVendorsTab_SelectVendors.TabIndex = 0
            Me.TabControlPanelSelectVendorsTab_SelectVendors.TabItem = Me.TabItemMCS_SelectVendorsTab
            '
            'DataGridViewSelectVendors_Vendors
            '
            Me.DataGridViewSelectVendors_Vendors.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectVendors_Vendors.AllowDragAndDrop = False
            Me.DataGridViewSelectVendors_Vendors.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectVendors_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectVendors_Vendors.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectVendors_Vendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectVendors_Vendors.AutoFilterLookupColumns = False
            Me.DataGridViewSelectVendors_Vendors.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectVendors_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewSelectVendors_Vendors.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectVendors_Vendors.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectVendors_Vendors.Enabled = False
            Me.DataGridViewSelectVendors_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectVendors_Vendors.ItemDescription = "Vendor(s)"
            Me.DataGridViewSelectVendors_Vendors.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectVendors_Vendors.MultiSelect = True
            Me.DataGridViewSelectVendors_Vendors.Name = "DataGridViewSelectVendors_Vendors"
            Me.DataGridViewSelectVendors_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectVendors_Vendors.RunStandardValidation = True
            Me.DataGridViewSelectVendors_Vendors.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectVendors_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectVendors_Vendors.Size = New System.Drawing.Size(677, 279)
            Me.DataGridViewSelectVendors_Vendors.TabIndex = 2
            Me.DataGridViewSelectVendors_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewSelectVendors_Vendors.ViewCaptionHeight = -1
            '
            'RadioButtonSelectVendors_AllVendors
            '
            Me.RadioButtonSelectVendors_AllVendors.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectVendors_AllVendors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectVendors_AllVendors.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectVendors_AllVendors.Checked = True
            Me.RadioButtonSelectVendors_AllVendors.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectVendors_AllVendors.CheckValue = "Y"
            Me.RadioButtonSelectVendors_AllVendors.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectVendors_AllVendors.Name = "RadioButtonSelectVendors_AllVendors"
            Me.RadioButtonSelectVendors_AllVendors.SecurityEnabled = True
            Me.RadioButtonSelectVendors_AllVendors.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectVendors_AllVendors.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectVendors_AllVendors.TabIndex = 0
            Me.RadioButtonSelectVendors_AllVendors.TabOnEnter = True
            Me.RadioButtonSelectVendors_AllVendors.Text = "All Vendors"
            '
            'RadioButtonSelectVendors_ChooseVendors
            '
            Me.RadioButtonSelectVendors_ChooseVendors.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectVendors_ChooseVendors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectVendors_ChooseVendors.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectVendors_ChooseVendors.Location = New System.Drawing.Point(148, 4)
            Me.RadioButtonSelectVendors_ChooseVendors.Name = "RadioButtonSelectVendors_ChooseVendors"
            Me.RadioButtonSelectVendors_ChooseVendors.SecurityEnabled = True
            Me.RadioButtonSelectVendors_ChooseVendors.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectVendors_ChooseVendors.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectVendors_ChooseVendors.TabIndex = 1
            Me.RadioButtonSelectVendors_ChooseVendors.TabOnEnter = True
            Me.RadioButtonSelectVendors_ChooseVendors.TabStop = False
            Me.RadioButtonSelectVendors_ChooseVendors.Text = "Choose Vendors"
            '
            'TabItemMCS_SelectVendorsTab
            '
            Me.TabItemMCS_SelectVendorsTab.AttachedControl = Me.TabControlPanelSelectVendorsTab_SelectVendors
            Me.TabItemMCS_SelectVendorsTab.Name = "TabItemMCS_SelectVendorsTab"
            Me.TabItemMCS_SelectVendorsTab.Text = "Select Vendors"
            '
            'TabControlPanelSelectMarketsTab_SelectMarkets
            '
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Controls.Add(Me.DataGridViewSelectMarkets_Markets)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Controls.Add(Me.RadioButtonSelectMarkets_AllMarkets)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Controls.Add(Me.RadioButtonSelectMarkets_ChooseMarkets)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Name = "TabControlPanelSelectMarketsTab_SelectMarkets"
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Size = New System.Drawing.Size(685, 313)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Style.GradientAngle = 90
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.TabIndex = 0
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.TabItem = Me.TabItemMCS_SelectMarketsTab
            '
            'DataGridViewSelectMarkets_Markets
            '
            Me.DataGridViewSelectMarkets_Markets.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectMarkets_Markets.AllowDragAndDrop = False
            Me.DataGridViewSelectMarkets_Markets.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectMarkets_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectMarkets_Markets.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectMarkets_Markets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectMarkets_Markets.AutoFilterLookupColumns = False
            Me.DataGridViewSelectMarkets_Markets.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectMarkets_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewSelectMarkets_Markets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectMarkets_Markets.DataSource = Nothing
            Me.DataGridViewSelectMarkets_Markets.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectMarkets_Markets.Enabled = False
            Me.DataGridViewSelectMarkets_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectMarkets_Markets.ItemDescription = "Market(s)"
            Me.DataGridViewSelectMarkets_Markets.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectMarkets_Markets.MultiSelect = True
            Me.DataGridViewSelectMarkets_Markets.Name = "DataGridViewSelectMarkets_Markets"
            Me.DataGridViewSelectMarkets_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectMarkets_Markets.RunStandardValidation = True
            Me.DataGridViewSelectMarkets_Markets.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectMarkets_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectMarkets_Markets.Size = New System.Drawing.Size(677, 279)
            Me.DataGridViewSelectMarkets_Markets.TabIndex = 2
            Me.DataGridViewSelectMarkets_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewSelectMarkets_Markets.ViewCaptionHeight = -1
            '
            'RadioButtonSelectMarkets_AllMarkets
            '
            Me.RadioButtonSelectMarkets_AllMarkets.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectMarkets_AllMarkets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectMarkets_AllMarkets.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectMarkets_AllMarkets.Checked = True
            Me.RadioButtonSelectMarkets_AllMarkets.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectMarkets_AllMarkets.CheckValue = "Y"
            Me.RadioButtonSelectMarkets_AllMarkets.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectMarkets_AllMarkets.Name = "RadioButtonSelectMarkets_AllMarkets"
            Me.RadioButtonSelectMarkets_AllMarkets.SecurityEnabled = True
            Me.RadioButtonSelectMarkets_AllMarkets.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectMarkets_AllMarkets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectMarkets_AllMarkets.TabIndex = 0
            Me.RadioButtonSelectMarkets_AllMarkets.TabOnEnter = True
            Me.RadioButtonSelectMarkets_AllMarkets.Text = "All Markets"
            '
            'RadioButtonSelectMarkets_ChooseMarkets
            '
            Me.RadioButtonSelectMarkets_ChooseMarkets.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectMarkets_ChooseMarkets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectMarkets_ChooseMarkets.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectMarkets_ChooseMarkets.Location = New System.Drawing.Point(148, 4)
            Me.RadioButtonSelectMarkets_ChooseMarkets.Name = "RadioButtonSelectMarkets_ChooseMarkets"
            Me.RadioButtonSelectMarkets_ChooseMarkets.SecurityEnabled = True
            Me.RadioButtonSelectMarkets_ChooseMarkets.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectMarkets_ChooseMarkets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectMarkets_ChooseMarkets.TabIndex = 1
            Me.RadioButtonSelectMarkets_ChooseMarkets.TabOnEnter = True
            Me.RadioButtonSelectMarkets_ChooseMarkets.TabStop = False
            Me.RadioButtonSelectMarkets_ChooseMarkets.Text = "Choose Markets"
            '
            'TabItemMCS_SelectMarketsTab
            '
            Me.TabItemMCS_SelectMarketsTab.AttachedControl = Me.TabControlPanelSelectMarketsTab_SelectMarkets
            Me.TabItemMCS_SelectMarketsTab.Name = "TabItemMCS_SelectMarketsTab"
            Me.TabItemMCS_SelectMarketsTab.Text = "Select Markets"
            '
            'MediaCurrentStatusSummaryInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(850, 509)
            Me.Controls.Add(Me.TabControlForm_MCS)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaCurrentStatusSummaryInitialLoadingDialog"
            Me.Text = "Media Current Status Summary"
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_MCS.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            Me.PanelOptions_Dates.ResumeLayout(False)
            CType(Me.NumericInputMonthlyBroadcast_ToYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerNonDailyBroadcast_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputMonthlyBroadcast_FromYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerNonDailyBroadcast_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOptions_MediaTypes.ResumeLayout(False)
            Me.PanelOptions_Include.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.ResumeLayout(False)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_MCS As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMCS_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelOptions_Include As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelOptions_Include As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonInclude_OpenOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonInclude_OpenAndClosed As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelOptions_MediaTypes As System.Windows.Forms.Panel
        Friend WithEvents LabelOptions_MediaTypes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxMediaTypes_All As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Television As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Internet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Radio As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMediaTypes_Magazine As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelOptions_NonDailyBroadcast As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNonDailyBroadcast_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNonDailyBroadcast_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMonthlyBroadcast_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMonthlyBroadcast_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOptions_MonthlyBroadcast As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerNonDailyBroadcast_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerNonDailyBroadcast_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents NumericInputMonthlyBroadcast_FromYear As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxMonthlyBroadcast_FromMonth As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputMonthlyBroadcast_ToYear As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxMonthlyBroadcast_ToMonth As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMCS_SelectCDPTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMCS_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewSelectOffices_Offices As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_AllOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents CheckBoxBroadcastDates As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelOptions_SelectBy As WinForm.Presentation.Controls.Label
        Friend WithEvents PanelOptions_Dates As Windows.Forms.Panel
        Friend WithEvents RadioButtonDates_Standard As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDates_Broadcast As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanelSelectVendorsTab_SelectVendors As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectVendors_Vendors As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectVendors_AllVendors As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectVendors_ChooseVendors As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemMCS_SelectVendorsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectMarketsTab_SelectMarkets As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectMarkets_Markets As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectMarkets_AllMarkets As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectMarkets_ChooseMarkets As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemMCS_SelectMarketsTab As DevComponents.DotNetBar.TabItem
    End Class

End Namespace
