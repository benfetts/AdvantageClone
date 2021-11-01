Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeHoursAllocationInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeHoursAllocationInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlForm_MCS = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBox_IncludeActuals = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Actualized = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.RadioButtonControl_Day = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_Month = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_Week = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_To = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_From = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.TabItemMCS_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectEmployees_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectEmployees_ChooseEmployees = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectEmployees_AllEmployees = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectEmployeesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectRoles_Roles = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectRoles_ChooseRoles = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectRoles_AllRoles = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectRolesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectDepartments_Departments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectDepartments_ChooseDepartments = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectDepartments_AllDepartments = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectDepartmentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_MCS.SuspendLayout()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel4.SuspendLayout()
            Me.TabControlPanel3.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
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
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel4)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel3)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel2)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel1)
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
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemJDA_SelectDepartmentsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemJDA_SelectRolesTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemJDA_SelectEmployeesTab)
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBox_IncludeActuals)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.CheckBoxForm_Actualized)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBox2)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelBy)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelForm_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.DateTimePickerForm_To)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.DateTimePickerForm_From)
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
            'CheckBox_IncludeActuals
            '
            '
            '
            '
            Me.CheckBox_IncludeActuals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBox_IncludeActuals.CheckValue = 0
            Me.CheckBox_IncludeActuals.CheckValueChecked = 1
            Me.CheckBox_IncludeActuals.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBox_IncludeActuals.CheckValueUnchecked = 0
            Me.CheckBox_IncludeActuals.ChildControls = CType(resources.GetObject("CheckBox_IncludeActuals.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox_IncludeActuals.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBox_IncludeActuals.Location = New System.Drawing.Point(55, 93)
            Me.CheckBox_IncludeActuals.Name = "CheckBox_IncludeActuals"
            Me.CheckBox_IncludeActuals.OldestSibling = Nothing
            Me.CheckBox_IncludeActuals.SecurityEnabled = True
            Me.CheckBox_IncludeActuals.SiblingControls = CType(resources.GetObject("CheckBox_IncludeActuals.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox_IncludeActuals.Size = New System.Drawing.Size(175, 20)
            Me.CheckBox_IncludeActuals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBox_IncludeActuals.TabIndex = 62
            Me.CheckBox_IncludeActuals.TabOnEnter = True
            Me.CheckBox_IncludeActuals.Text = "Include Actuals"
            '
            'CheckBoxForm_Actualized
            '
            '
            '
            '
            Me.CheckBoxForm_Actualized.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Actualized.CheckValue = 0
            Me.CheckBoxForm_Actualized.CheckValueChecked = 1
            Me.CheckBoxForm_Actualized.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Actualized.CheckValueUnchecked = 0
            Me.CheckBoxForm_Actualized.ChildControls = CType(resources.GetObject("CheckBoxForm_Actualized.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Actualized.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Actualized.Location = New System.Drawing.Point(408, 8)
            Me.CheckBoxForm_Actualized.Name = "CheckBoxForm_Actualized"
            Me.CheckBoxForm_Actualized.OldestSibling = Nothing
            Me.CheckBoxForm_Actualized.SecurityEnabled = True
            Me.CheckBoxForm_Actualized.SiblingControls = CType(resources.GetObject("CheckBoxForm_Actualized.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Actualized.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxForm_Actualized.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Actualized.TabIndex = 61
            Me.CheckBoxForm_Actualized.TabOnEnter = True
            Me.CheckBoxForm_Actualized.Text = "Actualized"
            Me.CheckBoxForm_Actualized.Visible = False
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.SystemColors.Window
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_Day)
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_Month)
            Me.GroupBox2.Controls.Add(Me.RadioButtonControl_Week)
            Me.GroupBox2.Location = New System.Drawing.Point(55, 37)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(206, 41)
            Me.GroupBox2.TabIndex = 60
            Me.GroupBox2.TabStop = False
            '
            'RadioButtonControl_Day
            '
            Me.RadioButtonControl_Day.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Day.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Day.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Day.Location = New System.Drawing.Point(8, 10)
            Me.RadioButtonControl_Day.Name = "RadioButtonControl_Day"
            Me.RadioButtonControl_Day.SecurityEnabled = True
            Me.RadioButtonControl_Day.Size = New System.Drawing.Size(56, 20)
            Me.RadioButtonControl_Day.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Day.TabIndex = 62
            Me.RadioButtonControl_Day.TabOnEnter = True
            Me.RadioButtonControl_Day.TabStop = False
            Me.RadioButtonControl_Day.Text = "Day"
            '
            'RadioButtonControl_Month
            '
            Me.RadioButtonControl_Month.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Month.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Month.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Month.Location = New System.Drawing.Point(140, 10)
            Me.RadioButtonControl_Month.Name = "RadioButtonControl_Month"
            Me.RadioButtonControl_Month.SecurityEnabled = True
            Me.RadioButtonControl_Month.Size = New System.Drawing.Size(56, 20)
            Me.RadioButtonControl_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Month.TabIndex = 53
            Me.RadioButtonControl_Month.TabOnEnter = True
            Me.RadioButtonControl_Month.TabStop = False
            Me.RadioButtonControl_Month.Text = "Month"
            '
            'RadioButtonControl_Week
            '
            Me.RadioButtonControl_Week.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_Week.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_Week.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_Week.Location = New System.Drawing.Point(72, 10)
            Me.RadioButtonControl_Week.Name = "RadioButtonControl_Week"
            Me.RadioButtonControl_Week.SecurityEnabled = True
            Me.RadioButtonControl_Week.Size = New System.Drawing.Size(56, 20)
            Me.RadioButtonControl_Week.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_Week.TabIndex = 52
            Me.RadioButtonControl_Week.TabOnEnter = True
            Me.RadioButtonControl_Week.TabStop = False
            Me.RadioButtonControl_Week.Text = "Week"
            '
            'LabelBy
            '
            Me.LabelBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBy.Location = New System.Drawing.Point(10, 47)
            Me.LabelBy.Name = "LabelBy"
            Me.LabelBy.Size = New System.Drawing.Size(37, 20)
            Me.LabelBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBy.TabIndex = 58
            Me.LabelBy.Text = "By:"
            '
            'LabelForm_To
            '
            Me.LabelForm_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_To.Location = New System.Drawing.Point(194, 8)
            Me.LabelForm_To.Name = "LabelForm_To"
            Me.LabelForm_To.Size = New System.Drawing.Size(31, 20)
            Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_To.TabIndex = 27
            Me.LabelForm_To.Text = "To:"
            '
            'LabelForm_From
            '
            Me.LabelForm_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_From.Location = New System.Drawing.Point(10, 8)
            Me.LabelForm_From.Name = "LabelForm_From"
            Me.LabelForm_From.Size = New System.Drawing.Size(37, 20)
            Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_From.TabIndex = 25
            Me.LabelForm_From.Text = "From:"
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
            Me.DateTimePickerForm_To.Location = New System.Drawing.Point(227, 8)
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
            Me.DateTimePickerForm_To.TabIndex = 28
            Me.DateTimePickerForm_To.TabOnEnter = True
            Me.DateTimePickerForm_To.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
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
            Me.DateTimePickerForm_From.Location = New System.Drawing.Point(55, 8)
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
            Me.DateTimePickerForm_From.TabIndex = 26
            Me.DateTimePickerForm_From.TabOnEnter = True
            Me.DateTimePickerForm_From.Value = New Date(1850, 1, 1, 0, 0, 0, 0)
            '
            'TabItemMCS_OptionsTab
            '
            Me.TabItemMCS_OptionsTab.AttachedControl = Me.TabControlPanelOptionsTab_Options
            Me.TabItemMCS_OptionsTab.Name = "TabItemMCS_OptionsTab"
            Me.TabItemMCS_OptionsTab.Text = "Options"
            '
            'TabControlPanel4
            '
            Me.TabControlPanel4.Controls.Add(Me.DataGridViewSelectEmployees_Employees)
            Me.TabControlPanel4.Controls.Add(Me.RadioButtonSelectEmployees_ChooseEmployees)
            Me.TabControlPanel4.Controls.Add(Me.RadioButtonSelectEmployees_AllEmployees)
            Me.TabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel4.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel4.Name = "TabControlPanel4"
            Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel4.Size = New System.Drawing.Size(685, 279)
            Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel4.Style.GradientAngle = 90
            Me.TabControlPanel4.TabIndex = 4
            Me.TabControlPanel4.TabItem = Me.TabItemJDA_SelectEmployeesTab
            '
            'DataGridViewSelectEmployees_Employees
            '
            Me.DataGridViewSelectEmployees_Employees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectEmployees_Employees.AllowDragAndDrop = False
            Me.DataGridViewSelectEmployees_Employees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectEmployees_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectEmployees_Employees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectEmployees_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectEmployees_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewSelectEmployees_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectEmployees_Employees.AutoUpdateViewCaption = True
            Me.DataGridViewSelectEmployees_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectEmployees_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectEmployees_Employees.Enabled = False
            Me.DataGridViewSelectEmployees_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectEmployees_Employees.ItemDescription = "Employee(s)"
            Me.DataGridViewSelectEmployees_Employees.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectEmployees_Employees.MultiSelect = True
            Me.DataGridViewSelectEmployees_Employees.Name = "DataGridViewSelectEmployees_Employees"
            Me.DataGridViewSelectEmployees_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectEmployees_Employees.RunStandardValidation = True
            Me.DataGridViewSelectEmployees_Employees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectEmployees_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectEmployees_Employees.Size = New System.Drawing.Size(677, 245)
            Me.DataGridViewSelectEmployees_Employees.TabIndex = 3
            Me.DataGridViewSelectEmployees_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewSelectEmployees_Employees.ViewCaptionHeight = -1
            '
            'RadioButtonSelectEmployees_ChooseEmployees
            '
            Me.RadioButtonSelectEmployees_ChooseEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectEmployees_ChooseEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectEmployees_ChooseEmployees.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectEmployees_ChooseEmployees.Location = New System.Drawing.Point(111, 4)
            Me.RadioButtonSelectEmployees_ChooseEmployees.Name = "RadioButtonSelectEmployees_ChooseEmployees"
            Me.RadioButtonSelectEmployees_ChooseEmployees.SecurityEnabled = True
            Me.RadioButtonSelectEmployees_ChooseEmployees.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectEmployees_ChooseEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectEmployees_ChooseEmployees.TabIndex = 2
            Me.RadioButtonSelectEmployees_ChooseEmployees.TabOnEnter = True
            Me.RadioButtonSelectEmployees_ChooseEmployees.TabStop = False
            Me.RadioButtonSelectEmployees_ChooseEmployees.Text = "Choose Employees"
            '
            'RadioButtonSelectEmployees_AllEmployees
            '
            Me.RadioButtonSelectEmployees_AllEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectEmployees_AllEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectEmployees_AllEmployees.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectEmployees_AllEmployees.Checked = True
            Me.RadioButtonSelectEmployees_AllEmployees.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectEmployees_AllEmployees.CheckValue = "Y"
            Me.RadioButtonSelectEmployees_AllEmployees.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectEmployees_AllEmployees.Name = "RadioButtonSelectEmployees_AllEmployees"
            Me.RadioButtonSelectEmployees_AllEmployees.SecurityEnabled = True
            Me.RadioButtonSelectEmployees_AllEmployees.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonSelectEmployees_AllEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectEmployees_AllEmployees.TabIndex = 1
            Me.RadioButtonSelectEmployees_AllEmployees.TabOnEnter = True
            Me.RadioButtonSelectEmployees_AllEmployees.Text = "All Employees"
            '
            'TabItemJDA_SelectEmployeesTab
            '
            Me.TabItemJDA_SelectEmployeesTab.AttachedControl = Me.TabControlPanel4
            Me.TabItemJDA_SelectEmployeesTab.Name = "TabItemJDA_SelectEmployeesTab"
            Me.TabItemJDA_SelectEmployeesTab.Text = "Select Employees"
            '
            'TabControlPanel3
            '
            Me.TabControlPanel3.Controls.Add(Me.DataGridViewSelectRoles_Roles)
            Me.TabControlPanel3.Controls.Add(Me.RadioButtonSelectRoles_ChooseRoles)
            Me.TabControlPanel3.Controls.Add(Me.RadioButtonSelectRoles_AllRoles)
            Me.TabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel3.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel3.Name = "TabControlPanel3"
            Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel3.Size = New System.Drawing.Size(685, 279)
            Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel3.Style.GradientAngle = 90
            Me.TabControlPanel3.TabIndex = 4
            Me.TabControlPanel3.TabItem = Me.TabItemJDA_SelectRolesTab
            '
            'DataGridViewSelectRoles_Roles
            '
            Me.DataGridViewSelectRoles_Roles.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectRoles_Roles.AllowDragAndDrop = False
            Me.DataGridViewSelectRoles_Roles.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectRoles_Roles.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectRoles_Roles.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectRoles_Roles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectRoles_Roles.AutoFilterLookupColumns = False
            Me.DataGridViewSelectRoles_Roles.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectRoles_Roles.AutoUpdateViewCaption = True
            Me.DataGridViewSelectRoles_Roles.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectRoles_Roles.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectRoles_Roles.Enabled = False
            Me.DataGridViewSelectRoles_Roles.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectRoles_Roles.ItemDescription = "Role(s)"
            Me.DataGridViewSelectRoles_Roles.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectRoles_Roles.MultiSelect = True
            Me.DataGridViewSelectRoles_Roles.Name = "DataGridViewSelectRoles_Roles"
            Me.DataGridViewSelectRoles_Roles.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectRoles_Roles.RunStandardValidation = True
            Me.DataGridViewSelectRoles_Roles.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectRoles_Roles.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectRoles_Roles.Size = New System.Drawing.Size(677, 245)
            Me.DataGridViewSelectRoles_Roles.TabIndex = 3
            Me.DataGridViewSelectRoles_Roles.UseEmbeddedNavigator = False
            Me.DataGridViewSelectRoles_Roles.ViewCaptionHeight = -1
            '
            'RadioButtonSelectRoles_ChooseRoles
            '
            Me.RadioButtonSelectRoles_ChooseRoles.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectRoles_ChooseRoles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectRoles_ChooseRoles.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectRoles_ChooseRoles.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectRoles_ChooseRoles.Name = "RadioButtonSelectRoles_ChooseRoles"
            Me.RadioButtonSelectRoles_ChooseRoles.SecurityEnabled = True
            Me.RadioButtonSelectRoles_ChooseRoles.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectRoles_ChooseRoles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectRoles_ChooseRoles.TabIndex = 2
            Me.RadioButtonSelectRoles_ChooseRoles.TabOnEnter = True
            Me.RadioButtonSelectRoles_ChooseRoles.TabStop = False
            Me.RadioButtonSelectRoles_ChooseRoles.Text = "Choose Roles"
            '
            'RadioButtonSelectRoles_AllRoles
            '
            Me.RadioButtonSelectRoles_AllRoles.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectRoles_AllRoles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectRoles_AllRoles.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectRoles_AllRoles.Checked = True
            Me.RadioButtonSelectRoles_AllRoles.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectRoles_AllRoles.CheckValue = "Y"
            Me.RadioButtonSelectRoles_AllRoles.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectRoles_AllRoles.Name = "RadioButtonSelectRoles_AllRoles"
            Me.RadioButtonSelectRoles_AllRoles.SecurityEnabled = True
            Me.RadioButtonSelectRoles_AllRoles.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectRoles_AllRoles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectRoles_AllRoles.TabIndex = 1
            Me.RadioButtonSelectRoles_AllRoles.TabOnEnter = True
            Me.RadioButtonSelectRoles_AllRoles.Text = "All Roles"
            '
            'TabItemJDA_SelectRolesTab
            '
            Me.TabItemJDA_SelectRolesTab.AttachedControl = Me.TabControlPanel3
            Me.TabItemJDA_SelectRolesTab.Name = "TabItemJDA_SelectRolesTab"
            Me.TabItemJDA_SelectRolesTab.Text = "Select Roles"
            '
            'TabControlPanel2
            '
            Me.TabControlPanel2.Controls.Add(Me.DataGridViewSelectDepartments_Departments)
            Me.TabControlPanel2.Controls.Add(Me.RadioButtonSelectDepartments_ChooseDepartments)
            Me.TabControlPanel2.Controls.Add(Me.RadioButtonSelectDepartments_AllDepartments)
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
            Me.TabControlPanel2.TabIndex = 4
            Me.TabControlPanel2.TabItem = Me.TabItemJDA_SelectDepartmentsTab
            '
            'DataGridViewSelectDepartments_Departments
            '
            Me.DataGridViewSelectDepartments_Departments.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectDepartments_Departments.AllowDragAndDrop = False
            Me.DataGridViewSelectDepartments_Departments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectDepartments_Departments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectDepartments_Departments.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectDepartments_Departments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectDepartments_Departments.AutoFilterLookupColumns = False
            Me.DataGridViewSelectDepartments_Departments.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectDepartments_Departments.AutoUpdateViewCaption = True
            Me.DataGridViewSelectDepartments_Departments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectDepartments_Departments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectDepartments_Departments.Enabled = False
            Me.DataGridViewSelectDepartments_Departments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectDepartments_Departments.ItemDescription = "Department(s)"
            Me.DataGridViewSelectDepartments_Departments.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectDepartments_Departments.MultiSelect = True
            Me.DataGridViewSelectDepartments_Departments.Name = "DataGridViewSelectDepartments_Departments"
            Me.DataGridViewSelectDepartments_Departments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectDepartments_Departments.RunStandardValidation = True
            Me.DataGridViewSelectDepartments_Departments.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectDepartments_Departments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectDepartments_Departments.Size = New System.Drawing.Size(677, 245)
            Me.DataGridViewSelectDepartments_Departments.TabIndex = 3
            Me.DataGridViewSelectDepartments_Departments.UseEmbeddedNavigator = False
            Me.DataGridViewSelectDepartments_Departments.ViewCaptionHeight = -1
            '
            'RadioButtonSelectDepartments_ChooseDepartments
            '
            Me.RadioButtonSelectDepartments_ChooseDepartments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectDepartments_ChooseDepartments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectDepartments_ChooseDepartments.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectDepartments_ChooseDepartments.Location = New System.Drawing.Point(111, 4)
            Me.RadioButtonSelectDepartments_ChooseDepartments.Name = "RadioButtonSelectDepartments_ChooseDepartments"
            Me.RadioButtonSelectDepartments_ChooseDepartments.SecurityEnabled = True
            Me.RadioButtonSelectDepartments_ChooseDepartments.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectDepartments_ChooseDepartments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabIndex = 2
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabOnEnter = True
            Me.RadioButtonSelectDepartments_ChooseDepartments.TabStop = False
            Me.RadioButtonSelectDepartments_ChooseDepartments.Text = "Choose Departments"
            '
            'RadioButtonSelectDepartments_AllDepartments
            '
            Me.RadioButtonSelectDepartments_AllDepartments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectDepartments_AllDepartments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectDepartments_AllDepartments.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectDepartments_AllDepartments.Checked = True
            Me.RadioButtonSelectDepartments_AllDepartments.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectDepartments_AllDepartments.CheckValue = "Y"
            Me.RadioButtonSelectDepartments_AllDepartments.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectDepartments_AllDepartments.Name = "RadioButtonSelectDepartments_AllDepartments"
            Me.RadioButtonSelectDepartments_AllDepartments.SecurityEnabled = True
            Me.RadioButtonSelectDepartments_AllDepartments.Size = New System.Drawing.Size(101, 20)
            Me.RadioButtonSelectDepartments_AllDepartments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectDepartments_AllDepartments.TabIndex = 1
            Me.RadioButtonSelectDepartments_AllDepartments.TabOnEnter = True
            Me.RadioButtonSelectDepartments_AllDepartments.Text = "All Departments"
            '
            'TabItemJDA_SelectDepartmentsTab
            '
            Me.TabItemJDA_SelectDepartmentsTab.AttachedControl = Me.TabControlPanel2
            Me.TabItemJDA_SelectDepartmentsTab.Name = "TabItemJDA_SelectDepartmentsTab"
            Me.TabItemJDA_SelectDepartmentsTab.Text = "Select Departments"
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
            Me.DataGridViewSelectOffices_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOffices_Offices.Enabled = False
            Me.DataGridViewSelectOffices_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOffices_Offices.ItemDescription = "Office(s)"
            Me.DataGridViewSelectOffices_Offices.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectOffices_Offices.MultiSelect = True
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
            'EmployeeHoursAllocationInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(709, 356)
            Me.Controls.Add(Me.TabControlForm_MCS)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeHoursAllocationInitialLoadingDialog"
            Me.Text = "Employee Hours Allocation Initial Criteria"
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_MCS.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.DateTimePickerForm_To, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_From, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel4.ResumeLayout(False)
            Me.TabControlPanel3.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_MCS As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_AllOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewSelectRoles_Roles As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectRoles_ChooseRoles As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectRoles_AllRoles As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectRolesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewSelectDepartments_Departments As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectDepartments_ChooseDepartments As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectDepartments_AllDepartments As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectDepartmentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewSelectEmployees_Employees As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectEmployees_ChooseEmployees As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectEmployees_AllEmployees As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectEmployeesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMCS_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelForm_To As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_From As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_To As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_From As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
        Friend WithEvents RadioButtonControl_Week As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl_Month As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelBy As WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Actualized As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControl_Day As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBox_IncludeActuals As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace