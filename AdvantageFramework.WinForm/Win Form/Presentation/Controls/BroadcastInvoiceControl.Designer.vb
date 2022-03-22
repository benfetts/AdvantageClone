Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BroadcastInvoiceControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BroadcastInvoiceControl))
            Me.TabControlForm_MCS = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.RadioButtonForm_OpenOrdersOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_OpenAndClosedOrders = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_Include = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_MonthFrom = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxForm_TV = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Radio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxForm_MonthTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputForm_YearFrom = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputForm_YearTo = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
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
            CType(Me.NumericInputForm_YearFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_YearTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel2.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.SuspendLayout()
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
            Me.TabControlForm_MCS.Location = New System.Drawing.Point(0, 0)
            Me.TabControlForm_MCS.Name = "TabControlForm_MCS"
            Me.TabControlForm_MCS.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_MCS.SelectedTabIndex = 0
            Me.TabControlForm_MCS.Size = New System.Drawing.Size(685, 306)
            Me.TabControlForm_MCS.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_MCS.TabIndex = 1
            Me.TabControlForm_MCS.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_OptionsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectClientsTab)
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.RadioButtonForm_OpenOrdersOnly)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.RadioButtonForm_OpenAndClosedOrders)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_Include)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_MediaType)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxForm_MonthFrom)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxForm_TV)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxForm_Radio)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxForm_MonthTo)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.NumericInputForm_YearFrom)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.NumericInputForm_YearTo)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(685, 279)
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
            'RadioButtonForm_OpenOrdersOnly
            '
            Me.RadioButtonForm_OpenOrdersOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_OpenOrdersOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_OpenOrdersOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_OpenOrdersOnly.Location = New System.Drawing.Point(246, 82)
            Me.RadioButtonForm_OpenOrdersOnly.Name = "RadioButtonForm_OpenOrdersOnly"
            Me.RadioButtonForm_OpenOrdersOnly.SecurityEnabled = True
            Me.RadioButtonForm_OpenOrdersOnly.Size = New System.Drawing.Size(128, 20)
            Me.RadioButtonForm_OpenOrdersOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_OpenOrdersOnly.TabIndex = 11
            Me.RadioButtonForm_OpenOrdersOnly.TabOnEnter = True
            Me.RadioButtonForm_OpenOrdersOnly.TabStop = False
            Me.RadioButtonForm_OpenOrdersOnly.Text = "Open Orders Only"
            '
            'RadioButtonForm_OpenAndClosedOrders
            '
            Me.RadioButtonForm_OpenAndClosedOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_OpenAndClosedOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_OpenAndClosedOrders.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_OpenAndClosedOrders.Checked = True
            Me.RadioButtonForm_OpenAndClosedOrders.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_OpenAndClosedOrders.CheckValue = "Y"
            Me.RadioButtonForm_OpenAndClosedOrders.Location = New System.Drawing.Point(112, 82)
            Me.RadioButtonForm_OpenAndClosedOrders.Name = "RadioButtonForm_OpenAndClosedOrders"
            Me.RadioButtonForm_OpenAndClosedOrders.SecurityEnabled = True
            Me.RadioButtonForm_OpenAndClosedOrders.Size = New System.Drawing.Size(128, 20)
            Me.RadioButtonForm_OpenAndClosedOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_OpenAndClosedOrders.TabIndex = 10
            Me.RadioButtonForm_OpenAndClosedOrders.TabOnEnter = True
            Me.RadioButtonForm_OpenAndClosedOrders.Text = "Open && Closed Orders"
            '
            'LabelForm_Include
            '
            Me.LabelForm_Include.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Include.Location = New System.Drawing.Point(5, 82)
            Me.LabelForm_Include.Name = "LabelForm_Include"
            Me.LabelForm_Include.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Include.TabIndex = 9
            Me.LabelForm_Include.Text = "Include:"
            '
            'LabelForm_MediaType
            '
            Me.LabelForm_MediaType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaType.Location = New System.Drawing.Point(4, 56)
            Me.LabelForm_MediaType.Name = "LabelForm_MediaType"
            Me.LabelForm_MediaType.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaType.TabIndex = 6
            Me.LabelForm_MediaType.Text = "Media Type:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(5, 5)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 0
            Me.LabelForm_From.Text = "From:"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(5, 30)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 3
            Me.LabelForm_To.Text = "To:"
            '
            'ComboBoxForm_MonthFrom
            '
            Me.ComboBoxForm_MonthFrom.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_MonthFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxForm_MonthFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_MonthFrom.AutoFindItemInDataSource = True
            Me.ComboBoxForm_MonthFrom.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_MonthFrom.BookmarkingEnabled = False
            Me.ComboBoxForm_MonthFrom.ClientCode = ""
            Me.ComboBoxForm_MonthFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxForm_MonthFrom.DisableMouseWheel = True
            Me.ComboBoxForm_MonthFrom.DisplayMember = "Value"
            Me.ComboBoxForm_MonthFrom.DisplayName = ""
            Me.ComboBoxForm_MonthFrom.DivisionCode = ""
            Me.ComboBoxForm_MonthFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_MonthFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_MonthFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_MonthFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_MonthFrom.FocusHighlightEnabled = True
            Me.ComboBoxForm_MonthFrom.FormattingEnabled = True
            Me.ComboBoxForm_MonthFrom.ItemHeight = 14
            Me.ComboBoxForm_MonthFrom.Location = New System.Drawing.Point(112, 4)
            Me.ComboBoxForm_MonthFrom.Name = "ComboBoxForm_MonthFrom"
            Me.ComboBoxForm_MonthFrom.ReadOnly = False
            Me.ComboBoxForm_MonthFrom.SecurityEnabled = True
            Me.ComboBoxForm_MonthFrom.Size = New System.Drawing.Size(128, 20)
            Me.ComboBoxForm_MonthFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MonthFrom.TabIndex = 1
            Me.ComboBoxForm_MonthFrom.TabOnEnter = True
            Me.ComboBoxForm_MonthFrom.ValueMember = "Key"
            Me.ComboBoxForm_MonthFrom.WatermarkText = "Select Month"
            '
            'CheckBoxForm_TV
            '
            Me.CheckBoxForm_TV.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxForm_TV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_TV.CheckValue = 0
            Me.CheckBoxForm_TV.CheckValueChecked = 1
            Me.CheckBoxForm_TV.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_TV.CheckValueUnchecked = 0
            Me.CheckBoxForm_TV.ChildControls = CType(resources.GetObject("CheckBoxForm_TV.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TV.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_TV.Location = New System.Drawing.Point(246, 56)
            Me.CheckBoxForm_TV.Name = "CheckBoxForm_TV"
            Me.CheckBoxForm_TV.OldestSibling = Nothing
            Me.CheckBoxForm_TV.SecurityEnabled = True
            Me.CheckBoxForm_TV.SiblingControls = CType(resources.GetObject("CheckBoxForm_TV.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TV.Size = New System.Drawing.Size(116, 20)
            Me.CheckBoxForm_TV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_TV.TabIndex = 8
            Me.CheckBoxForm_TV.TabOnEnter = True
            Me.CheckBoxForm_TV.Text = "TV"
            '
            'CheckBoxForm_Radio
            '
            Me.CheckBoxForm_Radio.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxForm_Radio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Radio.CheckValue = 0
            Me.CheckBoxForm_Radio.CheckValueChecked = 1
            Me.CheckBoxForm_Radio.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Radio.CheckValueUnchecked = 0
            Me.CheckBoxForm_Radio.ChildControls = CType(resources.GetObject("CheckBoxForm_Radio.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Radio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Radio.Location = New System.Drawing.Point(112, 56)
            Me.CheckBoxForm_Radio.Name = "CheckBoxForm_Radio"
            Me.CheckBoxForm_Radio.OldestSibling = Nothing
            Me.CheckBoxForm_Radio.SecurityEnabled = True
            Me.CheckBoxForm_Radio.SiblingControls = CType(resources.GetObject("CheckBoxForm_Radio.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Radio.Size = New System.Drawing.Size(91, 20)
            Me.CheckBoxForm_Radio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Radio.TabIndex = 7
            Me.CheckBoxForm_Radio.TabOnEnter = True
            Me.CheckBoxForm_Radio.Text = "Radio"
            '
            'ComboBoxForm_MonthTo
            '
            Me.ComboBoxForm_MonthTo.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_MonthTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxForm_MonthTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_MonthTo.AutoFindItemInDataSource = True
            Me.ComboBoxForm_MonthTo.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_MonthTo.BookmarkingEnabled = False
            Me.ComboBoxForm_MonthTo.ClientCode = ""
            Me.ComboBoxForm_MonthTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxForm_MonthTo.DisableMouseWheel = True
            Me.ComboBoxForm_MonthTo.DisplayMember = "Value"
            Me.ComboBoxForm_MonthTo.DisplayName = ""
            Me.ComboBoxForm_MonthTo.DivisionCode = ""
            Me.ComboBoxForm_MonthTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_MonthTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_MonthTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_MonthTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_MonthTo.FocusHighlightEnabled = True
            Me.ComboBoxForm_MonthTo.FormattingEnabled = True
            Me.ComboBoxForm_MonthTo.ItemHeight = 14
            Me.ComboBoxForm_MonthTo.Location = New System.Drawing.Point(112, 30)
            Me.ComboBoxForm_MonthTo.Name = "ComboBoxForm_MonthTo"
            Me.ComboBoxForm_MonthTo.ReadOnly = False
            Me.ComboBoxForm_MonthTo.SecurityEnabled = True
            Me.ComboBoxForm_MonthTo.Size = New System.Drawing.Size(128, 20)
            Me.ComboBoxForm_MonthTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MonthTo.TabIndex = 4
            Me.ComboBoxForm_MonthTo.TabOnEnter = True
            Me.ComboBoxForm_MonthTo.ValueMember = "Key"
            Me.ComboBoxForm_MonthTo.WatermarkText = "Select Month"
            '
            'NumericInputForm_YearFrom
            '
            Me.NumericInputForm_YearFrom.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_YearFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_YearFrom.EditValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputForm_YearFrom.EnterMoveNextControl = True
            Me.NumericInputForm_YearFrom.Location = New System.Drawing.Point(246, 4)
            Me.NumericInputForm_YearFrom.Name = "NumericInputForm_YearFrom"
            Me.NumericInputForm_YearFrom.Properties.AllowMouseWheel = False
            Me.NumericInputForm_YearFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputForm_YearFrom.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_YearFrom.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_YearFrom.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_YearFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_YearFrom.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_YearFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_YearFrom.Properties.IsFloatValue = False
            Me.NumericInputForm_YearFrom.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_YearFrom.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_YearFrom.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputForm_YearFrom.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputForm_YearFrom.SecurityEnabled = True
            Me.NumericInputForm_YearFrom.Size = New System.Drawing.Size(44, 20)
            Me.NumericInputForm_YearFrom.TabIndex = 2
            '
            'NumericInputForm_YearTo
            '
            Me.NumericInputForm_YearTo.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_YearTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputForm_YearTo.EditValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputForm_YearTo.EnterMoveNextControl = True
            Me.NumericInputForm_YearTo.Location = New System.Drawing.Point(246, 30)
            Me.NumericInputForm_YearTo.Name = "NumericInputForm_YearTo"
            Me.NumericInputForm_YearTo.Properties.AllowMouseWheel = False
            Me.NumericInputForm_YearTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputForm_YearTo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_YearTo.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_YearTo.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_YearTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_YearTo.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_YearTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_YearTo.Properties.IsFloatValue = False
            Me.NumericInputForm_YearTo.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_YearTo.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_YearTo.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputForm_YearTo.Properties.MinValue = New Decimal(New Integer() {1980, 0, 0, 0})
            Me.NumericInputForm_YearTo.SecurityEnabled = True
            Me.NumericInputForm_YearTo.Size = New System.Drawing.Size(44, 20)
            Me.NumericInputForm_YearTo.TabIndex = 5
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
            Me.TabControlPanel2.Size = New System.Drawing.Size(685, 279)
            Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel2.Style.GradientAngle = 90
            Me.TabControlPanel2.TabIndex = 0
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
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(677, 271)
            Me.CDPChooserControlSelectClients_SelectClients.TabIndex = 0
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
            Me.TabControlPanel1.Size = New System.Drawing.Size(685, 279)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 0
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
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(677, 245)
            Me.DataGridViewSelectOffices_Offices.TabIndex = 2
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
            Me.RadioButtonSelectOffices_ChooseOffices.TabIndex = 1
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
            Me.RadioButtonSelectOffices_AllOffices.TabIndex = 0
            Me.RadioButtonSelectOffices_AllOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_AllOffices.Text = "All Offices"
            '
            'TabItemJDA_SelectOfficesTab
            '
            Me.TabItemJDA_SelectOfficesTab.AttachedControl = Me.TabControlPanel1
            Me.TabItemJDA_SelectOfficesTab.Name = "TabItemJDA_SelectOfficesTab"
            Me.TabItemJDA_SelectOfficesTab.Text = "Select Offices"
            '
            'BroadcastInvoiceControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlForm_MCS)
            Me.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.Name = "BroadcastInvoiceControl"
            Me.Size = New System.Drawing.Size(685, 306)
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_MCS.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            CType(Me.NumericInputForm_YearFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_YearTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel2.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TabControlForm_MCS As TabControl
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents RadioButtonForm_OpenOrdersOnly As RadioButtonControl
        Friend WithEvents RadioButtonForm_OpenAndClosedOrders As RadioButtonControl
        Friend WithEvents LabelForm_Include As Label
        Friend WithEvents LabelForm_MediaType As Label
        Friend WithEvents LabelForm_From As Label
        Friend WithEvents LabelForm_To As Label
        Friend WithEvents ComboBoxForm_MonthFrom As ComboBox
        Friend WithEvents CheckBoxForm_TV As CheckBox
        Friend WithEvents CheckBoxForm_Radio As CheckBox
        Friend WithEvents ComboBoxForm_MonthTo As ComboBox
        Friend WithEvents NumericInputForm_YearFrom As NumericInput
        Friend WithEvents NumericInputForm_YearTo As NumericInput
        Friend WithEvents TabItemMCS_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As CDPChooserControl
        Friend WithEvents TabItemMCS_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As DataGridView
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_AllOffices As RadioButtonControl
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
    End Class

End Namespace
