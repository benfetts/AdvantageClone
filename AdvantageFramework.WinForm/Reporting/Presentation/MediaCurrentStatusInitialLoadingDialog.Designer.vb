Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaCurrentStatusInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaCurrentStatusInitialLoadingDialog))
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
            Me.CheckBoxBroadcastDates = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelOptions_WarningMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_MonthlyBroadcast = New System.Windows.Forms.Panel()
            Me.NumericInputMonthlyBroadcast_ToYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxMonthlyBroadcast_ToMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputMonthlyBroadcast_FromYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxMonthlyBroadcast_FromMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMonthlyBroadcast_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMonthlyBroadcast_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonMonthlyBroadcast_BroadcastDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelOptions_MonthlyBroadcast = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_NonDailyBroadcast = New System.Windows.Forms.Panel()
            Me.DateTimePickerNonDailyBroadcast_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerNonDailyBroadcast_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelNonDailyBroadcast_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNonDailyBroadcast_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonNonDailyBroadcast_DateToBill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelOptions_NonDailyBroadcast = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_MediaTypes = New System.Windows.Forms.Panel()
            Me.CheckBoxMediaTypes_Television = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Internet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Radio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaTypes_All = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelOptions_MediaTypes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_Include = New System.Windows.Forms.Panel()
            Me.RadioButtonInclude_OpenOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonInclude_OpenAndClosed = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemMCS_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOrdersTab_SelectOrders = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOrders_Orders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOrders_AllOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOrders_ChooseOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectOrdersTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectMarkets_Markets = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectMarkets_AllMarkets = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectMarkets_ChooseMarkets = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectMarketsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectVendorsTab_SelectVendors = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectVendors_Vendors = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectVendors_AllVendors = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectVendors_ChooseVendors = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectVendorsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectCampaigns_Campaigns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectCampaigns_AllCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectCampaigns_ChooseCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectCampaignsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlSelectCDPsTab_SelectCDPs = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSelectCDP_SelectionCriteria = New System.Windows.Forms.Panel()
            Me.RadioButtonSelectionCriteria_Client = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectionCriteria_ClientDivision = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewSelectCDPs_CDPs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectCDPs_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectCDPs_Choose = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemMCS_SelectCDPsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_MCS.SuspendLayout()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            Me.PanelOptions_MonthlyBroadcast.SuspendLayout()
            CType(Me.NumericInputMonthlyBroadcast_ToYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputMonthlyBroadcast_FromYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOptions_NonDailyBroadcast.SuspendLayout()
            CType(Me.DateTimePickerNonDailyBroadcast_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerNonDailyBroadcast_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOptions_MediaTypes.SuspendLayout()
            Me.PanelOptions_Include.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
            Me.TabControlPanelSelectOrdersTab_SelectOrders.SuspendLayout()
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.SuspendLayout()
            Me.TabControlPanelSelectVendorsTab_SelectVendors.SuspendLayout()
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.SuspendLayout()
            Me.TabControlSelectCDPsTab_SelectCDPs.SuspendLayout()
            Me.PanelSelectCDP_SelectionCriteria.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(541, 343)
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
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(622, 343)
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
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelSelectOrdersTab_SelectOrders)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelOptionsTab_Options)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelSelectMarketsTab_SelectMarkets)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelSelectVendorsTab_SelectVendors)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanelSelectCampaignsTab_SelectCampaigns)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlSelectCDPsTab_SelectCDPs)
            Me.TabControlForm_MCS.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_MCS.Name = "TabControlForm_MCS"
            Me.TabControlForm_MCS.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_MCS.SelectedTabIndex = 0
            Me.TabControlForm_MCS.Size = New System.Drawing.Size(685, 325)
            Me.TabControlForm_MCS.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_MCS.TabIndex = 0
            Me.TabControlForm_MCS.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_OptionsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectOfficesTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectCDPsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectCampaignsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectVendorsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectMarketsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectOrdersTab)
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxBroadcastDates)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_WarningMessage)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_MonthlyBroadcast)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_MonthlyBroadcast)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_NonDailyBroadcast)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_NonDailyBroadcast)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_MediaTypes)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_MediaTypes)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.PanelOptions_Include)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_Include)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(685, 298)
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
            Me.CheckBoxBroadcastDates.Location = New System.Drawing.Point(22, 274)
            Me.CheckBoxBroadcastDates.Name = "CheckBoxBroadcastDates"
            Me.CheckBoxBroadcastDates.OldestSibling = Nothing
            Me.CheckBoxBroadcastDates.SecurityEnabled = True
            Me.CheckBoxBroadcastDates.SiblingControls = CType(resources.GetObject("CheckBoxBroadcastDates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBroadcastDates.Size = New System.Drawing.Size(210, 20)
            Me.CheckBoxBroadcastDates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBroadcastDates.TabIndex = 19
            Me.CheckBoxBroadcastDates.TabOnEnter = True
            Me.CheckBoxBroadcastDates.Text = "Select All by Broadcast Month/Year"
            Me.CheckBoxBroadcastDates.Visible = False
            '
            'LabelOptions_WarningMessage
            '
            Me.LabelOptions_WarningMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelOptions_WarningMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_WarningMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_WarningMessage.Location = New System.Drawing.Point(320, 274)
            Me.LabelOptions_WarningMessage.Name = "LabelOptions_WarningMessage"
            Me.LabelOptions_WarningMessage.Size = New System.Drawing.Size(359, 20)
            Me.LabelOptions_WarningMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_WarningMessage.TabIndex = 7
            Me.LabelOptions_WarningMessage.Text = "* Uses the first material close date of each order/month to select detail."
            Me.LabelOptions_WarningMessage.Visible = False
            '
            'PanelOptions_MonthlyBroadcast
            '
            Me.PanelOptions_MonthlyBroadcast.BackColor = System.Drawing.Color.White
            Me.PanelOptions_MonthlyBroadcast.Controls.Add(Me.NumericInputMonthlyBroadcast_ToYear)
            Me.PanelOptions_MonthlyBroadcast.Controls.Add(Me.ComboBoxMonthlyBroadcast_ToMonth)
            Me.PanelOptions_MonthlyBroadcast.Controls.Add(Me.NumericInputMonthlyBroadcast_FromYear)
            Me.PanelOptions_MonthlyBroadcast.Controls.Add(Me.ComboBoxMonthlyBroadcast_FromMonth)
            Me.PanelOptions_MonthlyBroadcast.Controls.Add(Me.LabelMonthlyBroadcast_To)
            Me.PanelOptions_MonthlyBroadcast.Controls.Add(Me.LabelMonthlyBroadcast_From)
            Me.PanelOptions_MonthlyBroadcast.Controls.Add(Me.RadioButtonMonthlyBroadcast_BroadcastDate)
            Me.PanelOptions_MonthlyBroadcast.Controls.Add(Me.RadioButtonMonthlyBroadcast_MaterialCloseDate)
            Me.PanelOptions_MonthlyBroadcast.Location = New System.Drawing.Point(320, 30)
            Me.PanelOptions_MonthlyBroadcast.Name = "PanelOptions_MonthlyBroadcast"
            Me.PanelOptions_MonthlyBroadcast.Size = New System.Drawing.Size(359, 63)
            Me.PanelOptions_MonthlyBroadcast.TabIndex = 6
            Me.PanelOptions_MonthlyBroadcast.Visible = False
            '
            'NumericInputMonthlyBroadcast_ToYear
            '
            Me.NumericInputMonthlyBroadcast_ToYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMonthlyBroadcast_ToYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMonthlyBroadcast_ToYear.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericInputMonthlyBroadcast_ToYear.EnterMoveNextControl = True
            Me.NumericInputMonthlyBroadcast_ToYear.Location = New System.Drawing.Point(316, 32)
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
            Me.NumericInputMonthlyBroadcast_ToYear.TabIndex = 9
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
            Me.ComboBoxMonthlyBroadcast_ToMonth.Location = New System.Drawing.Point(188, 32)
            Me.ComboBoxMonthlyBroadcast_ToMonth.Name = "ComboBoxMonthlyBroadcast_ToMonth"
            Me.ComboBoxMonthlyBroadcast_ToMonth.ReadOnly = False
            Me.ComboBoxMonthlyBroadcast_ToMonth.SecurityEnabled = True
            Me.ComboBoxMonthlyBroadcast_ToMonth.Size = New System.Drawing.Size(122, 20)
            Me.ComboBoxMonthlyBroadcast_ToMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMonthlyBroadcast_ToMonth.TabIndex = 8
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
            Me.NumericInputMonthlyBroadcast_FromYear.Location = New System.Drawing.Point(316, 6)
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
            Me.NumericInputMonthlyBroadcast_FromYear.TabIndex = 6
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
            Me.ComboBoxMonthlyBroadcast_FromMonth.Location = New System.Drawing.Point(188, 6)
            Me.ComboBoxMonthlyBroadcast_FromMonth.Name = "ComboBoxMonthlyBroadcast_FromMonth"
            Me.ComboBoxMonthlyBroadcast_FromMonth.ReadOnly = False
            Me.ComboBoxMonthlyBroadcast_FromMonth.SecurityEnabled = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.Size = New System.Drawing.Size(122, 20)
            Me.ComboBoxMonthlyBroadcast_FromMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMonthlyBroadcast_FromMonth.TabIndex = 5
            Me.ComboBoxMonthlyBroadcast_FromMonth.TabOnEnter = True
            Me.ComboBoxMonthlyBroadcast_FromMonth.ValueMember = "Key"
            Me.ComboBoxMonthlyBroadcast_FromMonth.WatermarkText = "Select Month"
            '
            'LabelMonthlyBroadcast_To
            '
            Me.LabelMonthlyBroadcast_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMonthlyBroadcast_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMonthlyBroadcast_To.Location = New System.Drawing.Point(140, 32)
            Me.LabelMonthlyBroadcast_To.Name = "LabelMonthlyBroadcast_To"
            Me.LabelMonthlyBroadcast_To.Size = New System.Drawing.Size(42, 20)
            Me.LabelMonthlyBroadcast_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMonthlyBroadcast_To.TabIndex = 7
            Me.LabelMonthlyBroadcast_To.Text = "To:"
            '
            'LabelMonthlyBroadcast_From
            '
            Me.LabelMonthlyBroadcast_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMonthlyBroadcast_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMonthlyBroadcast_From.Location = New System.Drawing.Point(140, 6)
            Me.LabelMonthlyBroadcast_From.Name = "LabelMonthlyBroadcast_From"
            Me.LabelMonthlyBroadcast_From.Size = New System.Drawing.Size(42, 20)
            Me.LabelMonthlyBroadcast_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMonthlyBroadcast_From.TabIndex = 4
            Me.LabelMonthlyBroadcast_From.Text = "From:"
            '
            'RadioButtonMonthlyBroadcast_BroadcastDate
            '
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.Checked = True
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.CheckValue = "Y"
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.Location = New System.Drawing.Point(0, 6)
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.Name = "RadioButtonMonthlyBroadcast_BroadcastDate"
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.SecurityEnabled = True
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.TabIndex = 0
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.TabOnEnter = True
            Me.RadioButtonMonthlyBroadcast_BroadcastDate.Text = "Broadcast Date"
            '
            'RadioButtonMonthlyBroadcast_MaterialCloseDate
            '
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.Location = New System.Drawing.Point(0, 32)
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.Name = "RadioButtonMonthlyBroadcast_MaterialCloseDate"
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.SecurityEnabled = True
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.TabIndex = 1
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.TabOnEnter = True
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.TabStop = False
            Me.RadioButtonMonthlyBroadcast_MaterialCloseDate.Text = "Material Close Date*"
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
            Me.LabelOptions_MonthlyBroadcast.Location = New System.Drawing.Point(320, 4)
            Me.LabelOptions_MonthlyBroadcast.Name = "LabelOptions_MonthlyBroadcast"
            Me.LabelOptions_MonthlyBroadcast.Size = New System.Drawing.Size(359, 20)
            Me.LabelOptions_MonthlyBroadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_MonthlyBroadcast.TabIndex = 5
            Me.LabelOptions_MonthlyBroadcast.Text = "Broadcast Month/Year"
            Me.LabelOptions_MonthlyBroadcast.Visible = False
            '
            'PanelOptions_NonDailyBroadcast
            '
            Me.PanelOptions_NonDailyBroadcast.BackColor = System.Drawing.Color.White
            Me.PanelOptions_NonDailyBroadcast.Controls.Add(Me.DateTimePickerNonDailyBroadcast_To)
            Me.PanelOptions_NonDailyBroadcast.Controls.Add(Me.DateTimePickerNonDailyBroadcast_From)
            Me.PanelOptions_NonDailyBroadcast.Controls.Add(Me.LabelNonDailyBroadcast_To)
            Me.PanelOptions_NonDailyBroadcast.Controls.Add(Me.LabelNonDailyBroadcast_From)
            Me.PanelOptions_NonDailyBroadcast.Controls.Add(Me.RadioButtonNonDailyBroadcast_SpaceCloseDate)
            Me.PanelOptions_NonDailyBroadcast.Controls.Add(Me.RadioButtonNonDailyBroadcast_MaterialCloseDate)
            Me.PanelOptions_NonDailyBroadcast.Controls.Add(Me.RadioButtonNonDailyBroadcast_InsertStartPostDate)
            Me.PanelOptions_NonDailyBroadcast.Controls.Add(Me.RadioButtonNonDailyBroadcast_DateToBill)
            Me.PanelOptions_NonDailyBroadcast.Location = New System.Drawing.Point(320, 125)
            Me.PanelOptions_NonDailyBroadcast.Name = "PanelOptions_NonDailyBroadcast"
            Me.PanelOptions_NonDailyBroadcast.Size = New System.Drawing.Size(359, 110)
            Me.PanelOptions_NonDailyBroadcast.TabIndex = 4
            Me.PanelOptions_NonDailyBroadcast.Visible = False
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
            Me.DateTimePickerNonDailyBroadcast_To.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerNonDailyBroadcast_To.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNonDailyBroadcast_To.DisplayName = ""
            Me.DateTimePickerNonDailyBroadcast_To.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNonDailyBroadcast_To.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNonDailyBroadcast_To.FocusHighlightEnabled = True
            Me.DateTimePickerNonDailyBroadcast_To.FreeTextEntryMode = True
            Me.DateTimePickerNonDailyBroadcast_To.IsPopupCalendarOpen = False
            Me.DateTimePickerNonDailyBroadcast_To.Location = New System.Drawing.Point(188, 26)
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
            Me.DateTimePickerNonDailyBroadcast_To.Size = New System.Drawing.Size(171, 20)
            Me.DateTimePickerNonDailyBroadcast_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNonDailyBroadcast_To.TabIndex = 7
            Me.DateTimePickerNonDailyBroadcast_To.TabOnEnter = True
            Me.DateTimePickerNonDailyBroadcast_To.Value = New Date(2013, 4, 16, 10, 23, 37, 356)
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
            Me.DateTimePickerNonDailyBroadcast_From.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerNonDailyBroadcast_From.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerNonDailyBroadcast_From.DisplayName = ""
            Me.DateTimePickerNonDailyBroadcast_From.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerNonDailyBroadcast_From.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerNonDailyBroadcast_From.FocusHighlightEnabled = True
            Me.DateTimePickerNonDailyBroadcast_From.FreeTextEntryMode = True
            Me.DateTimePickerNonDailyBroadcast_From.IsPopupCalendarOpen = False
            Me.DateTimePickerNonDailyBroadcast_From.Location = New System.Drawing.Point(188, 0)
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
            Me.DateTimePickerNonDailyBroadcast_From.Size = New System.Drawing.Size(172, 20)
            Me.DateTimePickerNonDailyBroadcast_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerNonDailyBroadcast_From.TabIndex = 5
            Me.DateTimePickerNonDailyBroadcast_From.TabOnEnter = True
            Me.DateTimePickerNonDailyBroadcast_From.Value = New Date(2013, 4, 16, 10, 23, 19, 434)
            '
            'LabelNonDailyBroadcast_To
            '
            Me.LabelNonDailyBroadcast_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNonDailyBroadcast_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNonDailyBroadcast_To.Location = New System.Drawing.Point(140, 26)
            Me.LabelNonDailyBroadcast_To.Name = "LabelNonDailyBroadcast_To"
            Me.LabelNonDailyBroadcast_To.Size = New System.Drawing.Size(42, 20)
            Me.LabelNonDailyBroadcast_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNonDailyBroadcast_To.TabIndex = 6
            Me.LabelNonDailyBroadcast_To.Text = "To:"
            '
            'LabelNonDailyBroadcast_From
            '
            Me.LabelNonDailyBroadcast_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNonDailyBroadcast_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNonDailyBroadcast_From.Location = New System.Drawing.Point(140, 0)
            Me.LabelNonDailyBroadcast_From.Name = "LabelNonDailyBroadcast_From"
            Me.LabelNonDailyBroadcast_From.Size = New System.Drawing.Size(42, 20)
            Me.LabelNonDailyBroadcast_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNonDailyBroadcast_From.TabIndex = 4
            Me.LabelNonDailyBroadcast_From.Text = "From:"
            '
            'RadioButtonNonDailyBroadcast_SpaceCloseDate
            '
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.Location = New System.Drawing.Point(0, 78)
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.Name = "RadioButtonNonDailyBroadcast_SpaceCloseDate"
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.SecurityEnabled = True
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.TabIndex = 3
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.TabOnEnter = True
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.TabStop = False
            Me.RadioButtonNonDailyBroadcast_SpaceCloseDate.Text = "Space Close Date"
            '
            'RadioButtonNonDailyBroadcast_MaterialCloseDate
            '
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.Location = New System.Drawing.Point(0, 52)
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.Name = "RadioButtonNonDailyBroadcast_MaterialCloseDate"
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.SecurityEnabled = True
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.TabIndex = 2
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.TabOnEnter = True
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.TabStop = False
            Me.RadioButtonNonDailyBroadcast_MaterialCloseDate.Text = "Material Close Date"
            '
            'RadioButtonNonDailyBroadcast_InsertStartPostDate
            '
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.Checked = True
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.CheckValue = "Y"
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.Name = "RadioButtonNonDailyBroadcast_InsertStartPostDate"
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.SecurityEnabled = True
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.TabIndex = 0
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.TabOnEnter = True
            Me.RadioButtonNonDailyBroadcast_InsertStartPostDate.Text = "Insert/Start/Post Date"
            '
            'RadioButtonNonDailyBroadcast_DateToBill
            '
            Me.RadioButtonNonDailyBroadcast_DateToBill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonNonDailyBroadcast_DateToBill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonNonDailyBroadcast_DateToBill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonNonDailyBroadcast_DateToBill.Location = New System.Drawing.Point(0, 26)
            Me.RadioButtonNonDailyBroadcast_DateToBill.Name = "RadioButtonNonDailyBroadcast_DateToBill"
            Me.RadioButtonNonDailyBroadcast_DateToBill.SecurityEnabled = True
            Me.RadioButtonNonDailyBroadcast_DateToBill.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonNonDailyBroadcast_DateToBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonNonDailyBroadcast_DateToBill.TabIndex = 1
            Me.RadioButtonNonDailyBroadcast_DateToBill.TabOnEnter = True
            Me.RadioButtonNonDailyBroadcast_DateToBill.TabStop = False
            Me.RadioButtonNonDailyBroadcast_DateToBill.Text = "Date To Bill"
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
            Me.LabelOptions_NonDailyBroadcast.Location = New System.Drawing.Point(320, 99)
            Me.LabelOptions_NonDailyBroadcast.Name = "LabelOptions_NonDailyBroadcast"
            Me.LabelOptions_NonDailyBroadcast.Size = New System.Drawing.Size(359, 20)
            Me.LabelOptions_NonDailyBroadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_NonDailyBroadcast.TabIndex = 3
            Me.LabelOptions_NonDailyBroadcast.Text = "Non-Broadcast"
            Me.LabelOptions_NonDailyBroadcast.Visible = False
            '
            'PanelOptions_MediaTypes
            '
            Me.PanelOptions_MediaTypes.BackColor = System.Drawing.Color.White
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Television)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_OutOfHome)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Internet)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Radio)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Newspaper)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_Magazine)
            Me.PanelOptions_MediaTypes.Controls.Add(Me.CheckBoxMediaTypes_All)
            Me.PanelOptions_MediaTypes.Location = New System.Drawing.Point(162, 33)
            Me.PanelOptions_MediaTypes.Name = "PanelOptions_MediaTypes"
            Me.PanelOptions_MediaTypes.Size = New System.Drawing.Size(152, 219)
            Me.PanelOptions_MediaTypes.TabIndex = 2
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
            Me.LabelOptions_MediaTypes.Location = New System.Drawing.Point(162, 4)
            Me.LabelOptions_MediaTypes.Name = "LabelOptions_MediaTypes"
            Me.LabelOptions_MediaTypes.Size = New System.Drawing.Size(152, 20)
            Me.LabelOptions_MediaTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_MediaTypes.TabIndex = 1
            Me.LabelOptions_MediaTypes.Text = "Media Types"
            '
            'PanelOptions_Include
            '
            Me.PanelOptions_Include.BackColor = System.Drawing.Color.White
            Me.PanelOptions_Include.Controls.Add(Me.RadioButtonInclude_OpenOnly)
            Me.PanelOptions_Include.Controls.Add(Me.RadioButtonInclude_OpenAndClosed)
            Me.PanelOptions_Include.Location = New System.Drawing.Point(8, 33)
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
            Me.LabelOptions_Include.Location = New System.Drawing.Point(8, 4)
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
            'TabControlPanelSelectOfficesTab_SelectOffices
            '
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.DataGridViewSelectOffices_Offices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectOffices_AllOffices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectOffices_ChooseOffices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Name = "TabControlPanelSelectOfficesTab_SelectOffices"
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Size = New System.Drawing.Size(685, 298)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.GradientAngle = 90
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabIndex = 0
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabItem = Me.TabItemMCS_SelectOfficesTab
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
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(677, 264)
            Me.DataGridViewSelectOffices_Offices.TabIndex = 2
            Me.DataGridViewSelectOffices_Offices.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOffices_Offices.ViewCaptionHeight = -1
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
            Me.RadioButtonSelectOffices_AllOffices.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectOffices_AllOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_AllOffices.TabIndex = 0
            Me.RadioButtonSelectOffices_AllOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_AllOffices.Text = "All Offices"
            '
            'RadioButtonSelectOffices_ChooseOffices
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_ChooseOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_ChooseOffices.Location = New System.Drawing.Point(148, 4)
            Me.RadioButtonSelectOffices_ChooseOffices.Name = "RadioButtonSelectOffices_ChooseOffices"
            Me.RadioButtonSelectOffices_ChooseOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_ChooseOffices.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectOffices_ChooseOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_ChooseOffices.TabIndex = 1
            Me.RadioButtonSelectOffices_ChooseOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_ChooseOffices.TabStop = False
            Me.RadioButtonSelectOffices_ChooseOffices.Text = "Choose Offices"
            '
            'TabItemMCS_SelectOfficesTab
            '
            Me.TabItemMCS_SelectOfficesTab.AttachedControl = Me.TabControlPanelSelectOfficesTab_SelectOffices
            Me.TabItemMCS_SelectOfficesTab.Name = "TabItemMCS_SelectOfficesTab"
            Me.TabItemMCS_SelectOfficesTab.Text = "Select Offices"
            '
            'TabControlPanelSelectOrdersTab_SelectOrders
            '
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Controls.Add(Me.DataGridViewSelectOrders_Orders)
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Controls.Add(Me.RadioButtonSelectOrders_AllOrders)
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Controls.Add(Me.RadioButtonSelectOrders_ChooseOrders)
            Me.TabControlPanelSelectOrdersTab_SelectOrders.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Name = "TabControlPanelSelectOrdersTab_SelectOrders"
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Size = New System.Drawing.Size(685, 298)
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectOrdersTab_SelectOrders.Style.GradientAngle = 90
            Me.TabControlPanelSelectOrdersTab_SelectOrders.TabIndex = 0
            Me.TabControlPanelSelectOrdersTab_SelectOrders.TabItem = Me.TabItemMCS_SelectOrdersTab
            '
            'DataGridViewSelectOrders_Orders
            '
            Me.DataGridViewSelectOrders_Orders.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectOrders_Orders.AllowDragAndDrop = False
            Me.DataGridViewSelectOrders_Orders.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectOrders_Orders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectOrders_Orders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectOrders_Orders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectOrders_Orders.AutoFilterLookupColumns = False
            Me.DataGridViewSelectOrders_Orders.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectOrders_Orders.AutoUpdateViewCaption = True
            Me.DataGridViewSelectOrders_Orders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectOrders_Orders.DataSource = Nothing
            Me.DataGridViewSelectOrders_Orders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOrders_Orders.Enabled = False
            Me.DataGridViewSelectOrders_Orders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOrders_Orders.ItemDescription = "Order(s)"
            Me.DataGridViewSelectOrders_Orders.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectOrders_Orders.MultiSelect = False
            Me.DataGridViewSelectOrders_Orders.Name = "DataGridViewSelectOrders_Orders"
            Me.DataGridViewSelectOrders_Orders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectOrders_Orders.RunStandardValidation = True
            Me.DataGridViewSelectOrders_Orders.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectOrders_Orders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOrders_Orders.Size = New System.Drawing.Size(677, 264)
            Me.DataGridViewSelectOrders_Orders.TabIndex = 2
            Me.DataGridViewSelectOrders_Orders.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOrders_Orders.ViewCaptionHeight = -1
            '
            'RadioButtonSelectOrders_AllOrders
            '
            Me.RadioButtonSelectOrders_AllOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOrders_AllOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOrders_AllOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOrders_AllOrders.Checked = True
            Me.RadioButtonSelectOrders_AllOrders.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectOrders_AllOrders.CheckValue = "Y"
            Me.RadioButtonSelectOrders_AllOrders.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectOrders_AllOrders.Name = "RadioButtonSelectOrders_AllOrders"
            Me.RadioButtonSelectOrders_AllOrders.SecurityEnabled = True
            Me.RadioButtonSelectOrders_AllOrders.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectOrders_AllOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOrders_AllOrders.TabIndex = 0
            Me.RadioButtonSelectOrders_AllOrders.TabOnEnter = True
            Me.RadioButtonSelectOrders_AllOrders.Text = "All Orders"
            '
            'RadioButtonSelectOrders_ChooseOrders
            '
            Me.RadioButtonSelectOrders_ChooseOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOrders_ChooseOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOrders_ChooseOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOrders_ChooseOrders.Location = New System.Drawing.Point(148, 4)
            Me.RadioButtonSelectOrders_ChooseOrders.Name = "RadioButtonSelectOrders_ChooseOrders"
            Me.RadioButtonSelectOrders_ChooseOrders.SecurityEnabled = True
            Me.RadioButtonSelectOrders_ChooseOrders.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonSelectOrders_ChooseOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOrders_ChooseOrders.TabIndex = 1
            Me.RadioButtonSelectOrders_ChooseOrders.TabOnEnter = True
            Me.RadioButtonSelectOrders_ChooseOrders.TabStop = False
            Me.RadioButtonSelectOrders_ChooseOrders.Text = "Choose Orders"
            '
            'TabItemMCS_SelectOrdersTab
            '
            Me.TabItemMCS_SelectOrdersTab.AttachedControl = Me.TabControlPanelSelectOrdersTab_SelectOrders
            Me.TabItemMCS_SelectOrdersTab.Name = "TabItemMCS_SelectOrdersTab"
            Me.TabItemMCS_SelectOrdersTab.Text = "Select Orders"
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
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.Size = New System.Drawing.Size(685, 298)
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
            Me.DataGridViewSelectMarkets_Markets.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectMarkets_Markets.Enabled = False
            Me.DataGridViewSelectMarkets_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectMarkets_Markets.ItemDescription = "Market(s)"
            Me.DataGridViewSelectMarkets_Markets.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectMarkets_Markets.MultiSelect = False
            Me.DataGridViewSelectMarkets_Markets.Name = "DataGridViewSelectMarkets_Markets"
            Me.DataGridViewSelectMarkets_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectMarkets_Markets.RunStandardValidation = True
            Me.DataGridViewSelectMarkets_Markets.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectMarkets_Markets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectMarkets_Markets.Size = New System.Drawing.Size(677, 264)
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
            Me.TabControlPanelSelectVendorsTab_SelectVendors.Size = New System.Drawing.Size(685, 298)
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
            Me.DataGridViewSelectVendors_Vendors.DataSource = Nothing
            Me.DataGridViewSelectVendors_Vendors.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectVendors_Vendors.Enabled = False
            Me.DataGridViewSelectVendors_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectVendors_Vendors.ItemDescription = "Vendor(s)"
            Me.DataGridViewSelectVendors_Vendors.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectVendors_Vendors.MultiSelect = False
            Me.DataGridViewSelectVendors_Vendors.Name = "DataGridViewSelectVendors_Vendors"
            Me.DataGridViewSelectVendors_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectVendors_Vendors.RunStandardValidation = True
            Me.DataGridViewSelectVendors_Vendors.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectVendors_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectVendors_Vendors.Size = New System.Drawing.Size(677, 264)
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
            'TabControlPanelSelectCampaignsTab_SelectCampaigns
            '
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Controls.Add(Me.DataGridViewSelectCampaigns_Campaigns)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Controls.Add(Me.RadioButtonSelectCampaigns_AllCampaigns)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Controls.Add(Me.RadioButtonSelectCampaigns_ChooseCampaigns)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Name = "TabControlPanelSelectCampaignsTab_SelectCampaigns"
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Size = New System.Drawing.Size(685, 298)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.Style.GradientAngle = 90
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.TabIndex = 0
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.TabItem = Me.TabItemMCS_SelectCampaignsTab
            '
            'DataGridViewSelectCampaigns_Campaigns
            '
            Me.DataGridViewSelectCampaigns_Campaigns.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectCampaigns_Campaigns.AllowDragAndDrop = False
            Me.DataGridViewSelectCampaigns_Campaigns.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectCampaigns_Campaigns.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectCampaigns_Campaigns.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectCampaigns_Campaigns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectCampaigns_Campaigns.AutoFilterLookupColumns = False
            Me.DataGridViewSelectCampaigns_Campaigns.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectCampaigns_Campaigns.AutoUpdateViewCaption = True
            Me.DataGridViewSelectCampaigns_Campaigns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectCampaigns_Campaigns.DataSource = Nothing
            Me.DataGridViewSelectCampaigns_Campaigns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectCampaigns_Campaigns.Enabled = False
            Me.DataGridViewSelectCampaigns_Campaigns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectCampaigns_Campaigns.ItemDescription = "Campaign(s)"
            Me.DataGridViewSelectCampaigns_Campaigns.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectCampaigns_Campaigns.MultiSelect = False
            Me.DataGridViewSelectCampaigns_Campaigns.Name = "DataGridViewSelectCampaigns_Campaigns"
            Me.DataGridViewSelectCampaigns_Campaigns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectCampaigns_Campaigns.RunStandardValidation = True
            Me.DataGridViewSelectCampaigns_Campaigns.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectCampaigns_Campaigns.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectCampaigns_Campaigns.Size = New System.Drawing.Size(677, 264)
            Me.DataGridViewSelectCampaigns_Campaigns.TabIndex = 2
            Me.DataGridViewSelectCampaigns_Campaigns.UseEmbeddedNavigator = False
            Me.DataGridViewSelectCampaigns_Campaigns.ViewCaptionHeight = -1
            '
            'RadioButtonSelectCampaigns_AllCampaigns
            '
            Me.RadioButtonSelectCampaigns_AllCampaigns.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectCampaigns_AllCampaigns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectCampaigns_AllCampaigns.Checked = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectCampaigns_AllCampaigns.CheckValue = "Y"
            Me.RadioButtonSelectCampaigns_AllCampaigns.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectCampaigns_AllCampaigns.Name = "RadioButtonSelectCampaigns_AllCampaigns"
            Me.RadioButtonSelectCampaigns_AllCampaigns.SecurityEnabled = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectCampaigns_AllCampaigns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectCampaigns_AllCampaigns.TabIndex = 0
            Me.RadioButtonSelectCampaigns_AllCampaigns.TabOnEnter = True
            Me.RadioButtonSelectCampaigns_AllCampaigns.Text = "All Campaigns"
            '
            'RadioButtonSelectCampaigns_ChooseCampaigns
            '
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Location = New System.Drawing.Point(148, 4)
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Name = "RadioButtonSelectCampaigns_ChooseCampaigns"
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.SecurityEnabled = True
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabIndex = 1
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabOnEnter = True
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.TabStop = False
            Me.RadioButtonSelectCampaigns_ChooseCampaigns.Text = "Choose Campaigns"
            '
            'TabItemMCS_SelectCampaignsTab
            '
            Me.TabItemMCS_SelectCampaignsTab.AttachedControl = Me.TabControlPanelSelectCampaignsTab_SelectCampaigns
            Me.TabItemMCS_SelectCampaignsTab.Name = "TabItemMCS_SelectCampaignsTab"
            Me.TabItemMCS_SelectCampaignsTab.Text = "Select Campaigns"
            '
            'TabControlSelectCDPsTab_SelectCDPs
            '
            Me.TabControlSelectCDPsTab_SelectCDPs.Controls.Add(Me.PanelSelectCDP_SelectionCriteria)
            Me.TabControlSelectCDPsTab_SelectCDPs.Controls.Add(Me.DataGridViewSelectCDPs_CDPs)
            Me.TabControlSelectCDPsTab_SelectCDPs.Controls.Add(Me.RadioButtonSelectCDPs_All)
            Me.TabControlSelectCDPsTab_SelectCDPs.Controls.Add(Me.RadioButtonSelectCDPs_Choose)
            Me.TabControlSelectCDPsTab_SelectCDPs.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlSelectCDPsTab_SelectCDPs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlSelectCDPsTab_SelectCDPs.Location = New System.Drawing.Point(0, 27)
            Me.TabControlSelectCDPsTab_SelectCDPs.Name = "TabControlSelectCDPsTab_SelectCDPs"
            Me.TabControlSelectCDPsTab_SelectCDPs.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlSelectCDPsTab_SelectCDPs.Size = New System.Drawing.Size(685, 298)
            Me.TabControlSelectCDPsTab_SelectCDPs.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlSelectCDPsTab_SelectCDPs.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlSelectCDPsTab_SelectCDPs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlSelectCDPsTab_SelectCDPs.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlSelectCDPsTab_SelectCDPs.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlSelectCDPsTab_SelectCDPs.Style.GradientAngle = 90
            Me.TabControlSelectCDPsTab_SelectCDPs.TabIndex = 0
            Me.TabControlSelectCDPsTab_SelectCDPs.TabItem = Me.TabItemMCS_SelectCDPsTab
            '
            'PanelSelectCDP_SelectionCriteria
            '
            Me.PanelSelectCDP_SelectionCriteria.BackColor = System.Drawing.Color.White
            Me.PanelSelectCDP_SelectionCriteria.Controls.Add(Me.RadioButtonSelectionCriteria_Client)
            Me.PanelSelectCDP_SelectionCriteria.Controls.Add(Me.RadioButtonSelectionCriteria_ClientDivisionProduct)
            Me.PanelSelectCDP_SelectionCriteria.Controls.Add(Me.RadioButtonSelectionCriteria_ClientDivision)
            Me.PanelSelectCDP_SelectionCriteria.Enabled = False
            Me.PanelSelectCDP_SelectionCriteria.Location = New System.Drawing.Point(4, 30)
            Me.PanelSelectCDP_SelectionCriteria.Name = "PanelSelectCDP_SelectionCriteria"
            Me.PanelSelectCDP_SelectionCriteria.Size = New System.Drawing.Size(677, 20)
            Me.PanelSelectCDP_SelectionCriteria.TabIndex = 7
            '
            'RadioButtonSelectionCriteria_Client
            '
            Me.RadioButtonSelectionCriteria_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectionCriteria_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectionCriteria_Client.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectionCriteria_Client.Checked = True
            Me.RadioButtonSelectionCriteria_Client.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectionCriteria_Client.CheckValue = "Y"
            Me.RadioButtonSelectionCriteria_Client.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonSelectionCriteria_Client.Name = "RadioButtonSelectionCriteria_Client"
            Me.RadioButtonSelectionCriteria_Client.SecurityEnabled = True
            Me.RadioButtonSelectionCriteria_Client.Size = New System.Drawing.Size(53, 20)
            Me.RadioButtonSelectionCriteria_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectionCriteria_Client.TabIndex = 4
            Me.RadioButtonSelectionCriteria_Client.TabOnEnter = True
            Me.RadioButtonSelectionCriteria_Client.Text = "Client"
            '
            'RadioButtonSelectionCriteria_ClientDivisionProduct
            '
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Location = New System.Drawing.Point(158, 0)
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Name = "RadioButtonSelectionCriteria_ClientDivisionProduct"
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.SecurityEnabled = True
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Size = New System.Drawing.Size(133, 20)
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.TabIndex = 6
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.TabOnEnter = True
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.TabStop = False
            Me.RadioButtonSelectionCriteria_ClientDivisionProduct.Text = "Client/Division/Product"
            '
            'RadioButtonSelectionCriteria_ClientDivision
            '
            Me.RadioButtonSelectionCriteria_ClientDivision.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectionCriteria_ClientDivision.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectionCriteria_ClientDivision.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectionCriteria_ClientDivision.Location = New System.Drawing.Point(59, 0)
            Me.RadioButtonSelectionCriteria_ClientDivision.Name = "RadioButtonSelectionCriteria_ClientDivision"
            Me.RadioButtonSelectionCriteria_ClientDivision.SecurityEnabled = True
            Me.RadioButtonSelectionCriteria_ClientDivision.Size = New System.Drawing.Size(93, 20)
            Me.RadioButtonSelectionCriteria_ClientDivision.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectionCriteria_ClientDivision.TabIndex = 5
            Me.RadioButtonSelectionCriteria_ClientDivision.TabOnEnter = True
            Me.RadioButtonSelectionCriteria_ClientDivision.TabStop = False
            Me.RadioButtonSelectionCriteria_ClientDivision.Text = "Client/Division"
            '
            'DataGridViewSelectCDPs_CDPs
            '
            Me.DataGridViewSelectCDPs_CDPs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectCDPs_CDPs.AllowDragAndDrop = False
            Me.DataGridViewSelectCDPs_CDPs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectCDPs_CDPs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectCDPs_CDPs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectCDPs_CDPs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectCDPs_CDPs.AutoFilterLookupColumns = False
            Me.DataGridViewSelectCDPs_CDPs.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectCDPs_CDPs.AutoUpdateViewCaption = True
            Me.DataGridViewSelectCDPs_CDPs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectCDPs_CDPs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectCDPs_CDPs.Enabled = False
            Me.DataGridViewSelectCDPs_CDPs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectCDPs_CDPs.ItemDescription = "Client(s)"
            Me.DataGridViewSelectCDPs_CDPs.Location = New System.Drawing.Point(4, 56)
            Me.DataGridViewSelectCDPs_CDPs.MultiSelect = False
            Me.DataGridViewSelectCDPs_CDPs.Name = "DataGridViewSelectCDPs_CDPs"
            Me.DataGridViewSelectCDPs_CDPs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectCDPs_CDPs.RunStandardValidation = True
            Me.DataGridViewSelectCDPs_CDPs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectCDPs_CDPs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectCDPs_CDPs.Size = New System.Drawing.Size(677, 238)
            Me.DataGridViewSelectCDPs_CDPs.TabIndex = 2
            Me.DataGridViewSelectCDPs_CDPs.UseEmbeddedNavigator = False
            Me.DataGridViewSelectCDPs_CDPs.ViewCaptionHeight = -1
            '
            'RadioButtonSelectCDPs_All
            '
            Me.RadioButtonSelectCDPs_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectCDPs_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectCDPs_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectCDPs_All.Checked = True
            Me.RadioButtonSelectCDPs_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectCDPs_All.CheckValue = "Y"
            Me.RadioButtonSelectCDPs_All.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectCDPs_All.Name = "RadioButtonSelectCDPs_All"
            Me.RadioButtonSelectCDPs_All.SecurityEnabled = True
            Me.RadioButtonSelectCDPs_All.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectCDPs_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectCDPs_All.TabIndex = 0
            Me.RadioButtonSelectCDPs_All.TabOnEnter = True
            Me.RadioButtonSelectCDPs_All.Text = "All"
            '
            'RadioButtonSelectCDPs_Choose
            '
            Me.RadioButtonSelectCDPs_Choose.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectCDPs_Choose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectCDPs_Choose.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectCDPs_Choose.Location = New System.Drawing.Point(148, 4)
            Me.RadioButtonSelectCDPs_Choose.Name = "RadioButtonSelectCDPs_Choose"
            Me.RadioButtonSelectCDPs_Choose.SecurityEnabled = True
            Me.RadioButtonSelectCDPs_Choose.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectCDPs_Choose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectCDPs_Choose.TabIndex = 1
            Me.RadioButtonSelectCDPs_Choose.TabOnEnter = True
            Me.RadioButtonSelectCDPs_Choose.TabStop = False
            Me.RadioButtonSelectCDPs_Choose.Text = "Choose"
            '
            'TabItemMCS_SelectCDPsTab
            '
            Me.TabItemMCS_SelectCDPsTab.AttachedControl = Me.TabControlSelectCDPsTab_SelectCDPs
            Me.TabItemMCS_SelectCDPsTab.Name = "TabItemMCS_SelectCDPsTab"
            Me.TabItemMCS_SelectCDPsTab.Text = "Select C/D/P"
            '
            'MediaCurrentStatusInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(709, 375)
            Me.Controls.Add(Me.TabControlForm_MCS)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaCurrentStatusInitialLoadingDialog"
            Me.Text = "Media Current Status"
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_MCS.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            Me.PanelOptions_MonthlyBroadcast.ResumeLayout(False)
            CType(Me.NumericInputMonthlyBroadcast_ToYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputMonthlyBroadcast_FromYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOptions_NonDailyBroadcast.ResumeLayout(False)
            CType(Me.DateTimePickerNonDailyBroadcast_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerNonDailyBroadcast_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOptions_MediaTypes.ResumeLayout(False)
            Me.PanelOptions_Include.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
            Me.TabControlPanelSelectOrdersTab_SelectOrders.ResumeLayout(False)
            Me.TabControlPanelSelectMarketsTab_SelectMarkets.ResumeLayout(False)
            Me.TabControlPanelSelectVendorsTab_SelectVendors.ResumeLayout(False)
            Me.TabControlPanelSelectCampaignsTab_SelectCampaigns.ResumeLayout(False)
            Me.TabControlSelectCDPsTab_SelectCDPs.ResumeLayout(False)
            Me.PanelSelectCDP_SelectionCriteria.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_MCS As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSelectCampaignsTab_SelectCampaigns As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectCampaigns_Campaigns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectCampaigns_AllCampaigns As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectCampaigns_ChooseCampaigns As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemMCS_SelectCampaignsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlSelectCDPsTab_SelectCDPs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectCDPs_CDPs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectCDPs_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectCDPs_Choose As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemMCS_SelectCDPsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_AllOffices As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemMCS_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMCS_OptionsTab As DevComponents.DotNetBar.TabItem
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
        Friend WithEvents PanelOptions_NonDailyBroadcast As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonNonDailyBroadcast_SpaceCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNonDailyBroadcast_MaterialCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNonDailyBroadcast_InsertStartPostDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonNonDailyBroadcast_DateToBill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelOptions_NonDailyBroadcast As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelSelectOrdersTab_SelectOrders As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOrders_Orders As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOrders_AllOrders As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOrders_ChooseOrders As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemMCS_SelectOrdersTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelNonDailyBroadcast_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNonDailyBroadcast_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOptions_WarningMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelOptions_MonthlyBroadcast As System.Windows.Forms.Panel
        Friend WithEvents LabelMonthlyBroadcast_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMonthlyBroadcast_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonMonthlyBroadcast_BroadcastDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMonthlyBroadcast_MaterialCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelOptions_MonthlyBroadcast As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerNonDailyBroadcast_To As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerNonDailyBroadcast_From As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents NumericInputMonthlyBroadcast_FromYear As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxMonthlyBroadcast_FromMonth As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputMonthlyBroadcast_ToYear As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ComboBoxMonthlyBroadcast_ToMonth As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonSelectionCriteria_Client As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectionCriteria_ClientDivision As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectionCriteria_ClientDivisionProduct As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelSelectCDP_SelectionCriteria As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxBroadcastDates As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace