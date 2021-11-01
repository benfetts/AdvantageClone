Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaResultsComparisonInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaResultsComparisonInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_MonthFrom = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_MonthTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputForm_YearFrom = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputForm_YearTo = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelForm_GroupByOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Period = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_AdNumber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabControlForm_MCS = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemMCS_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemMCS_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.NumericInputForm_YearFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_YearTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_MCS.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(541, 324)
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
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(622, 324)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(4, 31)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(42, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 3
            Me.LabelForm_To.Text = "To:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(4, 4)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(42, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 0
            Me.LabelForm_From.Text = "From:"
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
            Me.ComboBoxForm_MonthFrom.ItemHeight = 16
            Me.ComboBoxForm_MonthFrom.Location = New System.Drawing.Point(52, 4)
            Me.ComboBoxForm_MonthFrom.Name = "ComboBoxForm_MonthFrom"
            Me.ComboBoxForm_MonthFrom.ReadOnly = False
            Me.ComboBoxForm_MonthFrom.SecurityEnabled = True
            Me.ComboBoxForm_MonthFrom.Size = New System.Drawing.Size(75, 22)
            Me.ComboBoxForm_MonthFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MonthFrom.TabIndex = 1
            Me.ComboBoxForm_MonthFrom.TabOnEnter = True
            Me.ComboBoxForm_MonthFrom.ValueMember = "Key"
            Me.ComboBoxForm_MonthFrom.WatermarkText = "Select Month"
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
            Me.ComboBoxForm_MonthTo.ItemHeight = 16
            Me.ComboBoxForm_MonthTo.Location = New System.Drawing.Point(52, 32)
            Me.ComboBoxForm_MonthTo.Name = "ComboBoxForm_MonthTo"
            Me.ComboBoxForm_MonthTo.ReadOnly = False
            Me.ComboBoxForm_MonthTo.SecurityEnabled = True
            Me.ComboBoxForm_MonthTo.Size = New System.Drawing.Size(75, 22)
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
            Me.NumericInputForm_YearFrom.Location = New System.Drawing.Point(133, 4)
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
            Me.NumericInputForm_YearTo.Location = New System.Drawing.Point(133, 32)
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
            'LabelForm_GroupByOptions
            '
            Me.LabelForm_GroupByOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_GroupByOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GroupByOptions.Location = New System.Drawing.Point(4, 60)
            Me.LabelForm_GroupByOptions.Name = "LabelForm_GroupByOptions"
            Me.LabelForm_GroupByOptions.Size = New System.Drawing.Size(677, 20)
            Me.LabelForm_GroupByOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GroupByOptions.TabIndex = 14
            Me.LabelForm_GroupByOptions.Text = "Group By Options"
            '
            'CheckBoxForm_Vendor
            '
            Me.CheckBoxForm_Vendor.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxForm_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Vendor.CheckValue = 0
            Me.CheckBoxForm_Vendor.CheckValueChecked = 1
            Me.CheckBoxForm_Vendor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Vendor.CheckValueUnchecked = 0
            Me.CheckBoxForm_Vendor.ChildControls = CType(resources.GetObject("CheckBoxForm_Vendor.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Vendor.Location = New System.Drawing.Point(4, 86)
            Me.CheckBoxForm_Vendor.Name = "CheckBoxForm_Vendor"
            Me.CheckBoxForm_Vendor.OldestSibling = Nothing
            Me.CheckBoxForm_Vendor.SecurityEnabled = True
            Me.CheckBoxForm_Vendor.SiblingControls = CType(resources.GetObject("CheckBoxForm_Vendor.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Vendor.Size = New System.Drawing.Size(91, 20)
            Me.CheckBoxForm_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Vendor.TabIndex = 21
            Me.CheckBoxForm_Vendor.TabOnEnter = True
            Me.CheckBoxForm_Vendor.Text = "Vendor"
            '
            'CheckBoxForm_Period
            '
            Me.CheckBoxForm_Period.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxForm_Period.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Period.CheckValue = 0
            Me.CheckBoxForm_Period.CheckValueChecked = 1
            Me.CheckBoxForm_Period.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Period.CheckValueUnchecked = 0
            Me.CheckBoxForm_Period.ChildControls = CType(resources.GetObject("CheckBoxForm_Period.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Period.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Period.Location = New System.Drawing.Point(101, 86)
            Me.CheckBoxForm_Period.Name = "CheckBoxForm_Period"
            Me.CheckBoxForm_Period.OldestSibling = Nothing
            Me.CheckBoxForm_Period.SecurityEnabled = True
            Me.CheckBoxForm_Period.SiblingControls = CType(resources.GetObject("CheckBoxForm_Period.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Period.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxForm_Period.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Period.TabIndex = 22
            Me.CheckBoxForm_Period.TabOnEnter = True
            Me.CheckBoxForm_Period.Text = "Period"
            '
            'CheckBoxForm_SalesClass
            '
            Me.CheckBoxForm_SalesClass.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxForm_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_SalesClass.CheckValue = 0
            Me.CheckBoxForm_SalesClass.CheckValueChecked = 1
            Me.CheckBoxForm_SalesClass.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_SalesClass.CheckValueUnchecked = 0
            Me.CheckBoxForm_SalesClass.ChildControls = CType(resources.GetObject("CheckBoxForm_SalesClass.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_SalesClass.Location = New System.Drawing.Point(195, 86)
            Me.CheckBoxForm_SalesClass.Name = "CheckBoxForm_SalesClass"
            Me.CheckBoxForm_SalesClass.OldestSibling = Nothing
            Me.CheckBoxForm_SalesClass.SecurityEnabled = True
            Me.CheckBoxForm_SalesClass.SiblingControls = CType(resources.GetObject("CheckBoxForm_SalesClass.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SalesClass.Size = New System.Drawing.Size(88, 20)
            Me.CheckBoxForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_SalesClass.TabIndex = 23
            Me.CheckBoxForm_SalesClass.TabOnEnter = True
            Me.CheckBoxForm_SalesClass.Text = "Sales Class"
            '
            'CheckBoxForm_AdNumber
            '
            Me.CheckBoxForm_AdNumber.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxForm_AdNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AdNumber.CheckValue = 0
            Me.CheckBoxForm_AdNumber.CheckValueChecked = 1
            Me.CheckBoxForm_AdNumber.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_AdNumber.CheckValueUnchecked = 0
            Me.CheckBoxForm_AdNumber.ChildControls = CType(resources.GetObject("CheckBoxForm_AdNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AdNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AdNumber.Location = New System.Drawing.Point(289, 86)
            Me.CheckBoxForm_AdNumber.Name = "CheckBoxForm_AdNumber"
            Me.CheckBoxForm_AdNumber.OldestSibling = Nothing
            Me.CheckBoxForm_AdNumber.SecurityEnabled = True
            Me.CheckBoxForm_AdNumber.SiblingControls = CType(resources.GetObject("CheckBoxForm_AdNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AdNumber.Size = New System.Drawing.Size(91, 20)
            Me.CheckBoxForm_AdNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AdNumber.TabIndex = 24
            Me.CheckBoxForm_AdNumber.TabOnEnter = True
            Me.CheckBoxForm_AdNumber.Text = "Ad Number"
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
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel1)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel2)
            Me.TabControlForm_MCS.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_MCS.Name = "TabControlForm_MCS"
            Me.TabControlForm_MCS.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_MCS.SelectedTabIndex = 0
            Me.TabControlForm_MCS.Size = New System.Drawing.Size(685, 306)
            Me.TabControlForm_MCS.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_MCS.TabIndex = 25
            Me.TabControlForm_MCS.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_OptionsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectClientsTab)
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
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(677, 271)
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
            Me.TabControlPanel1.Size = New System.Drawing.Size(685, 279)
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
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(677, 245)
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
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxForm_AdNumber)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxForm_SalesClass)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxForm_MonthFrom)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxForm_Period)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxForm_Vendor)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxForm_MonthTo)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_GroupByOptions)
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
            'TabItemMCS_OptionsTab
            '
            Me.TabItemMCS_OptionsTab.AttachedControl = Me.TabControlPanelOptionsTab_Options
            Me.TabItemMCS_OptionsTab.Name = "TabItemMCS_OptionsTab"
            Me.TabItemMCS_OptionsTab.Text = "Options"
            '
            'MediaResultsComparisonInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(709, 356)
            Me.Controls.Add(Me.TabControlForm_MCS)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaResultsComparisonInitialLoadingDialog"
            Me.Text = "Media Results Comparison Initial Criteria"
            CType(Me.NumericInputForm_YearFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_YearTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_MCS.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_From As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_MonthFrom As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_MonthTo As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputForm_YearFrom As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputForm_YearTo As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelForm_GroupByOptions As WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Vendor As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Period As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_SalesClass As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_AdNumber As WinForm.Presentation.Controls.CheckBox
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
    End Class

End Namespace